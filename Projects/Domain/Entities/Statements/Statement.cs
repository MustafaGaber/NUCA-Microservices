using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class Statement : AggregateRoot
    {
        private readonly List<ExternalSuppliesItem> _externalSuppliesItems = new();
        public virtual IReadOnlyList<ExternalSuppliesItem> ExternalSuppliesItems => _externalSuppliesItems.ToList();

        private readonly List<StatementTable> _tables = new();
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
           .Select(table =>
           {
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

        private readonly List<StatementWithholding> _withholdings = new();
        public virtual IReadOnlyList<StatementWithholding> Withholdings => _withholdings.ToList();
        public List<string> ExecutionDepartments => _tables.Aggregate(new List<string> { },
            (departments, table) =>
            {
                departments.AddRange(table.Sections.Select(s => s.DepartmentId));
                return departments;
            }).Distinct().ToList();

        private readonly List<UserSubmission> _submissions = new();

        public List<UserSubmission> Submissions => _submissions.ToList();
        public string? Message { get; private set; }
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
        public Statement(long projectId, Boq boq, int index, DateOnly worksDate, bool final)
        {
            ProjectId = Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            Index = Guard.Against.NegativeOrZero(index);
            State = StatementState.Execution;
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
            if (previousStatement.State < StatementState.Adjusted || previousStatement.Index < 1)
            {
                throw new InvalidOperationException();
            }
            ProjectId = Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            State = StatementState.Execution;
            WorksDate = Guard.Against.Null(worksDate, nameof(worksDate));
            Final = final;
            PriceChangePercent = boq.PriceChangePercent;
            Index = previousStatement.Index + 1;
            _tables = boq.Tables.Select(table =>
            {
                var previousTable = previousStatement.Tables
                    .Where(t => t.Type == StatementTableType.Works)
                    .FirstOrDefault(t => t.BoqTableId == table.Id);
                return previousTable == null ? new StatementTable(table, StatementTableType.Works, table.Type) : new StatementTable(table, previousTable, StatementTableType.Works, table.Type);
            }).ToList();
            _tables.AddRange(boq.Tables.Select(table =>
            {
                var previousTable = previousStatement.Tables
                .Where(t => t.Type == StatementTableType.Supplies)
                .FirstOrDefault(t => t.BoqTableId == table.Id);
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
        public void Update(UpdateStatementModel model, bool isFirst)
        {
            if (State > StatementState.TechnicalOffice)
            {
                throw new InvalidOperationException();
            }
            model.Items.ForEach(item =>
            {
                if (!isFirst && (item.PreviousQuantity != null || item.PreviousNetPrice != null))
                {
                    throw new InvalidOperationException();
                }
                StatementTable table = _tables.First(table => table.Id == item.TableId);
                table.UpdateItem(
                   sectionId: item.SectionId,
                   itemId: item.ItemId,
                   previousQuantity: item.PreviousQuantity,
                   totalQuantity: item.TotalQuantity,
                   percentage: item.Percentage,
                   percentageDetails: item.PercentageDetails.Select(p => new PercentageDetail(p.Quantity, p.Percentage, p.Notes)).ToList(),
                   previousNetPrice: item.PreviousNetPrice
                );
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
                withholding?.Update(w.Name, w.Value, w.Type);
            });
            _withholdings.AddRange(withholdings.Where(w => w.Id == 0).Select(w => new StatementWithholding(w.Name, w.Value, w.Type)));
        }

        private void UpdateExternalSuppliesItems(List<ExternalItemModel> items)
        {
            _externalSuppliesItems.RemoveAll(item => !items.Any(i => i.Id == item.Id));
            items.ForEach(i =>
            {
                ExternalSuppliesItem? item = _externalSuppliesItems.Find(_i => _i.Id == i.Id);
                item?.Update(i.TotalQuantity, i.Percentage);
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

        public void ExecutionSubmit(string departmentId, string userId)
        {
            if (!(State == StatementState.Execution || State == StatementState.ReturnedToExecution))
            {
                throw new InvalidOperationException();
            }
            _submissions.Add(new UserSubmission(userId, PrivilegeType.Execution, departmentId, true));
            if (ExecutionDepartments.All(d => _submissions.Select(s => s.DepartmentId).Contains(d)))
            {
                State = StatementState.TechnicalOffice;
                Message = null;
            }
        }

        public void TechnicalOfficeApprove(string userId)
        {
            if (State != StatementState.TechnicalOffice) return;
            _submissions.Add(new UserSubmission(userId, PrivilegeType.TechnicalOffice, null, true));
            State = StatementState.Revision;
            Message = null;
        }

        public void TechnicalOfficeDisapprove(string userId, string? message)
        {
            if (State != StatementState.TechnicalOffice) return;
            _submissions.Add(new UserSubmission(userId, PrivilegeType.TechnicalOffice, null, false, message));
            State = StatementState.ReturnedToExecution;
            Message = message;
        }

        public void ReturnFromRevisionToExecution(string userId, string message)
        {
            if (State != StatementState.Revision) return;
            _submissions.Add(new UserSubmission(userId, PrivilegeType.Revision, null, false, message));
            State = StatementState.ReturnedToExecution;
            Message = message;
        }

        public void ReturnFromRevisionToTechnicalOffice(string userId, string message)
        {
            if (State != StatementState.Revision) return;
            _submissions.Add(new UserSubmission(userId, PrivilegeType.Revision, null, false, message));
            State = StatementState.ReturnedToTechnicalOffice;
            Message = message;
        }

        public void RevisionApprove(string userId)
        {
            if (State != StatementState.Revision) return;
            _submissions.Add(new UserSubmission(userId, PrivilegeType.Revision, null, true));
            State = StatementState.RevisionApproved;
            Message = null;
        }

        public void SetAdjusted()
        {
            // if (State != StatementState.RevisionApproved) return;
            State = StatementState.Adjusted;
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
