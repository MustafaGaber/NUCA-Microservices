using Ardalis.GuardClauses;
using NUCA.Projects.Application.Statements;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class Statement : AggregateRoot<long>
    {
        public long ProjectId { get; private set; }
        public int Index { get; private set; }

        private readonly List<StatementTable> _tables = new List<StatementTable>();
        public IReadOnlyList<StatementTable> Tables => _tables.ToList();
        public IReadOnlyList<StatementTable> WorksTables => _tables.Where(t => t.Type == StatementTableType.Works).ToList();
        public IReadOnlyList<StatementTable> SuppliesTables => _tables.Where(t => t.Type == StatementTableType.Supplies).ToList();

        public double PriceChangePercent { get; private set; }
        public DateOnly WorksDate { get; private set; }
        public DateOnly SubmissionDate { get; private set; }
        public bool Final { get; private set; }
        public StatementState State { get; private set; }
        public double TotalWorks { get; private set; }
        public double TotalSupplies { get; private set; }

        private readonly List<StatementWithholding> _withholdings = new List<StatementWithholding>();
        public virtual IReadOnlyList<StatementWithholding> Withholdings => _withholdings.ToList();

        protected Statement() { }
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
            _tables = boq.Tables.Select(table => new StatementTable(table, previousStatement.WorksTables.First(t => t.BoqTableId == table.Id), StatementTableType.Works, table.Type)).ToList();
            _tables.AddRange(boq.Tables.Select(table => new StatementTable(table, previousStatement.SuppliesTables.First(t => t.BoqTableId == table.Id), StatementTableType.Supplies, table.Type)));
            UpdateTotals();
        }
        public void Update(UpdateStatementModel model, long userId)
        {
            model.Items.ForEach(item =>
            {
                StatementTable table = _tables.First(table => table.Id == item.TableId);
                table.UpdateItem(item, userId);
            });
            UpdateWithholdings(model.Withholdings);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            TotalWorks = WorksTables.Sum(t => t.Total) * (100 + PriceChangePercent) / 100;
            TotalSupplies = SuppliesTables.Sum(t => t.Total);
        }

        private void UpdateWithholdings(List<WithholdingModel> withholdings)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
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

        /*public void AddWithholding(FromStatement withholding)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
            _withholdings.Add(withholding);
        }
        public void UpdateWithholding(long withholdingId, FromStatement withholding)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
            FromStatement? oldWithholding = _withholdings.Find(d => d.Id == withholdingId);
            if (oldWithholding != null)
            {
                oldWithholding.Update(withholding.Name, withholding.Value, withholding.Type);
            }
        }

        public void RemoveWithholding(long id)
        {
            if (State > StatementState.TechnicalOfficeState)
            {
                throw new InvalidOperationException();
            }
            FromStatement? withholding = _withholdings.Find(d => d.Id == id);
            if (withholding != null)
            {
                _withholdings.Remove(withholding);
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
