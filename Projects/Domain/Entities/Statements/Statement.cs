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

        //private readonly List<ExternalSuppliesTable> _externalSuppliesTables = new List<ExternalSuppliesTable>();
        public IReadOnlyList<StatementTable> Tables => _tables.ToList();
        public IReadOnlyList<StatementTable> WorksTables => _tables.Where(t => t.Type == StatementTableType.Works).ToList();
        public IReadOnlyList<StatementTable> SuppliesTables => _tables.Where(t => t.Type == StatementTableType.Supplies).ToList();
        //public IReadOnlyList<ExternalSuppliesTable> ExternalSuppliesTables => _externalSuppliesTables.ToList();
        public long ProjectId { get; private set; }
        public int Index { get; private set; }
        public double PriceChangePercent { get; private set; }
        public DateOnly WorksDate { get; private set; }
        public DateOnly SubmissionDate { get; private set; }
        public bool Final { get; private set; }
        public StatementState State { get; private set; }
        public double TotalWorksBeforePriceChange => TotalWorks * 100 / (100 + PriceChangePercent);
        public double TotalWorks { get; private set; }
        public double TotalSupplies { get; private set; }
        public double TotalWorksAndSupplies => TotalWorks + TotalSupplies;

        private readonly List<StatementWithholding> _withholdings = new List<StatementWithholding>();
        public virtual IReadOnlyList<StatementWithholding> Withholdings => _withholdings.ToList();

        protected Statement()
        {
            double totalWorks = WorksTables.Sum(t => t.Total) * (100 + PriceChangePercent) / 100;
            double totalSupplies = SuppliesTables.Sum(t => t.Total) + ExternalSuppliesItems.Sum(t => t.NetPrice);
            if (Math.Abs(totalWorks - TotalWorks) > 0.001)
            {
                throw new InvalidOperationException();
            }
            if (Math.Abs(totalSupplies - TotalSupplies) > 0.001)
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
                var previousTable = previousStatement.WorksTables.FirstOrDefault(t => t.BoqTableId == table.Id);
                return previousTable == null ? new StatementTable(table, StatementTableType.Works, table.Type) : new StatementTable(table, previousTable, StatementTableType.Works, table.Type);
            }).ToList();
            _tables.AddRange(boq.Tables.Select(table =>
            {
                var previousTable = previousStatement.SuppliesTables.FirstOrDefault(t => t.BoqTableId == table.Id);
                return previousTable == null ? new StatementTable(table, StatementTableType.Supplies, table.Type) : new StatementTable(table, previousTable, StatementTableType.Supplies, table.Type);
            }));
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
                table.UpdateItem(item, userId);
            });
            UpdateWithholdings(model.Withholdings);
            UpdateExternalSuppliesItems(model.ExternalSuppliesItems, userId);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            TotalWorks = WorksTables.Sum(t => t.Total) * (100 + PriceChangePercent) / 100;
            TotalSupplies = SuppliesTables.Sum(t => t.Total) + ExternalSuppliesItems.Sum(t => t.NetPrice);
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

        private void UpdateExternalSuppliesItems(List<ExternalItemModel> items, long userId)
        {
            _externalSuppliesItems.RemoveAll(item => !items.Any(i => i.Id == item.Id));
            items.ForEach(i =>
            {
                ExternalSuppliesItem? item = _externalSuppliesItems.Find(_i => _i.Id == i.Id);
                if (item != null)
                {
                    item.Update(i.TotalQuantity, i.Percentage, userId);
                }
            });
            _externalSuppliesItems.AddRange(
                items.Where(i => i.Id == 0)
                .Where(i => SuppliesTables.Any(t => t.Id == i.StatementTableId))
                .Select(i => new ExternalSuppliesItem(
                    departmentId: i.DepartmentId,
                    statementTableId: i.StatementTableId,
                    index: i.Index,
                    content: i.Content,
                    unit: i.Unit,
                    unitPrice: i.UnitPrice,
                    previousQuantity: i.PreviousQuantity,
                    totalQuantity: i.TotalQuantity,
                    percentage: i.Percentage,
                    userId: userId
                 )
            ));
        }

        /*public void AddWithholding(FromStatement item)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
            _withholdings.Add(item);
        }
        public void UpdateWithholding(long withholdingId, FromStatement item)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
            FromStatement? oldWithholding = _withholdings.Find(d => d.Id == withholdingId);
            if (oldWithholding != null)
            {
                oldWithholding.Update(item.Name, item.Value, item.Type);
            }
        }

        public void RemoveWithholding(long id)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
            FromStatement? item = _withholdings.Find(d => d.Id == id);
            if (item != null)
            {
                _withholdings.Remove(item);
            }
        }*/

        public void Submit()
        {
            // Todo
            State = StatementState.RevisionState;
        }

        internal void SetAdjustmentCreated()
        {
            State = StatementState.AdjustedState;
        }

    }
}
