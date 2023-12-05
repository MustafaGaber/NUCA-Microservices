using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class Statement : AggregateRoot<long>
    {
        private readonly List<ExternalSuppliesItem> _externalSuppliesItems = new List<ExternalSuppliesItem>();
        public virtual IReadOnlyList<ExternalSuppliesItem> ExternalSuppliesItems => _externalSuppliesItems.ToList();

        private readonly List<StatementTable> _tables = new List<StatementTable>();
        public IReadOnlyList<StatementTable> Tables => _tables.ToList();
        public IReadOnlyList<WorksTable> WorksTables => _tables.Where(t => t.Type == StatementTableType.Works)
            .Select(table =>
            new WorksTable()
            {
                Id = table.Id,
                Name = table.Name,
                Sections = table.Sections,
                BoqTableId = table.BoqTableId,
                BoqTableType = table.BoqTableType,
                PriceChangePercent = table.PriceChangePercent,
                TotalBeforePriceChange = table.TotalBeforePriceChange,
                Total = table.Total,
            }).ToList();

        public IReadOnlyList<SuppliesTable> SuppliesTables => _tables.Where(t => t.Type == StatementTableType.Supplies)
           .Select(table => {
               var externalSuppliesItems = _externalSuppliesItems.Where(i => i.SuppliesTableId == table.Id).ToList();
               var externalSuppliesItemsTotal = externalSuppliesItems.Sum(i => i.NetPrice);
               var TotalBeforePriceChange = table.TotalBeforePriceChange + externalSuppliesItemsTotal;
               return new SuppliesTable()
               {
                   Id = table.Id,
                   Name = table.Name,
                   Sections = table.Sections,
                   BoqTableId = table.BoqTableId,
                   BoqTableType = table.BoqTableType,
                   PriceChangePercent = table.PriceChangePercent,
                   ExternalSuppliesItems = externalSuppliesItems,
                   TotalBeforePriceChange = TotalBeforePriceChange,
                   Total = TotalBeforePriceChange
               };
           }).ToList();
        public long ProjectId { get; init; }
        public int Index { get; init; }
        public double PriceChangePercent { get; init; }
        public DateOnly WorksDate { get; init; }
        public DateOnly SubmissionDate { get; init; }
        public bool Final { get; init; }
        public StatementState State { get; private set; }
        public double TotalWorksBeforePriceChange => TotalWorks * 100 / (100 + PriceChangePercent);
        public double TotalWorks { get; private set; }
        public double TotalSupplies { get; private set; }
        public double TotalWorksAndSupplies => TotalWorks + TotalSupplies;

        private readonly List<StatementWithholding> _withholdings = new List<StatementWithholding>();
        public virtual IReadOnlyList<StatementWithholding> Withholdings => _withholdings.ToList();

        protected Statement()
        {
            if (Math.Abs(CalculateTotalWorks() - TotalWorks) > 0.001)
            {
                throw new InvalidOperationException();
            }
            if (Math.Abs(CalculateTotalSupplies() - TotalSupplies) > 0.001)
            {
                throw new InvalidOperationException();
            }
        }
        public Statement(long projectId, Boq boq, DateOnly worksDate, bool final)
        {
            ProjectId = Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            Index = 1;
            State = StatementState.ExecutionState;
            WorksDate = Guard.Against.Null(worksDate, nameof(worksDate));
            Final = final;
            PriceChangePercent = boq.PriceChangePercent;
            Guard.Against.Null(boq, nameof(boq));
            _tables = boq.Tables.Select(table => new StatementTable(table, StatementTableType.Works, table.Type)).ToList();
            _tables.AddRange(boq.Tables.Select(table => new StatementTable(table, StatementTableType.Supplies, table.Type)));
            UpdateTotals();
        }
        public Statement(long projectId, Boq boq, DateOnly worksDate, bool final, Statement previousStatement)
        {
            Guard.Against.Null(previousStatement, nameof(previousStatement));
            Guard.Against.Null(boq, nameof(boq));
            if (previousStatement.State < StatementState.AdjustedState || previousStatement.Index < 1)
            {
                throw new InvalidOperationException();
            }
            ProjectId = Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            State = StatementState.ExecutionState;
            WorksDate = Guard.Against.Null(worksDate, nameof(worksDate));
            Final = final;
            PriceChangePercent = boq.PriceChangePercent;
            Index = previousStatement.Index + 1;
            _tables = boq.Tables.Select(table =>
            {
                var previousTable = previousStatement.Tables.FirstOrDefault(t => t.BoqTableId == table.Id);
                return previousTable == null ? new StatementTable(table, StatementTableType.Works, table.Type) : new StatementTable(table, previousTable, StatementTableType.Works, table.Type);
            }).ToList();
            _tables.AddRange(boq.Tables.Select(table =>
            {
                var previousTable = previousStatement.Tables.FirstOrDefault(t => t.BoqTableId == table.Id);
                return previousTable == null ? new StatementTable(table, StatementTableType.Supplies, table.Type) : new StatementTable(table, previousTable, StatementTableType.Supplies, table.Type);
            }));
            _externalSuppliesItems = previousStatement.ExternalSuppliesItems.Select(item =>
            new ExternalSuppliesItem(
                suppliesTableId: item.SuppliesTableId,
                departmentId: item.DepartmentId,
                index: item.Index,
                content: item.Content,
                unit: item.Unit,
                unitPrice: item.UnitPrice,
                previousQuantity: item.TotalQuantity,
                totalQuantity: item.TotalQuantity,
                percentage: item.Percentage
            )).ToList();
            UpdateTotals();
        }
        public void Update(UpdateStatementModel model, long userId)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
            model.Items.ForEach(item =>
            {
                StatementTable table = _tables.First(table => table.Id == item.TableId);
                table.UpdateItem(item);
            });
            UpdateWithholdings(model.Withholdings);
            UpdateExternalSuppliesItems(model.ExternalSuppliesItems);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            TotalWorks = CalculateTotalWorks();
            TotalSupplies = CalculateTotalSupplies();
        }
        private void UpdateWithholdings(List<WithholdingModel> withholdings)
        {
            _withholdings.RemoveAll(withholding => !withholdings.Any(w => w.Id == withholding.Id));
            withholdings.ForEach(w =>
            {
                StatementWithholding? withholding = _withholdings.Find(_w => _w.Id == w.Id);
                if (withholding != null)
                {
                    withholding.Update(w.Name, w.Value, w.Type);
                }
            });
            _withholdings.AddRange(withholdings.Where(w => w.Id == 0).Select(w => new StatementWithholding(w.Name, w.Value, w.Type)));
        }

        private void UpdateExternalSuppliesItems(List<ExternalItemModel> items)
        {
            _externalSuppliesItems.RemoveAll(item => !items.Any(i => i.Id == item.Id));
            items.ForEach(i =>
            {
                ExternalSuppliesItem? item = _externalSuppliesItems.Find(_i => _i.Id == i.Id);
                if (item != null)
                {
                    item.Update(i.TotalQuantity, i.Percentage);
                }
            });
            _externalSuppliesItems.AddRange(items
                .Where(item => item.Id == 0)
                .Select(item => new ExternalSuppliesItem(
                    suppliesTableId: item.SuppliesTableId,
                    departmentId: item.DepartmentId,
                    index: item.Index,
                    content: item.Content,
                    unit: item.Unit,
                    unitPrice: item.UnitPrice,
                    previousQuantity: item.PreviousQuantity,
                    totalQuantity: item.TotalQuantity,
                    percentage: item.Percentage
                 )
            ));
        }

        public void Submit()
        {
            State = StatementState.RevisionState;
        }

        public void SetAdjustmentCreated()
        {
            State = StatementState.AdjustedState;
        }

        private double CalculateTotalWorks()
        {
            return WorksTables.Sum(t => t.Total) * (100 + PriceChangePercent) / 100;
        }

        private double CalculateTotalSupplies()
        {
            return SuppliesTables.Sum(t => t.Total); // + ExternalSuppliesItems.Sum(t => t.NetPrice);
        }
    }
}
