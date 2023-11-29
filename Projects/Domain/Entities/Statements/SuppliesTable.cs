/*using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class SuppliesTable : StatementTable
    {
        protected readonly List<ExternalSuppliesTable> _externalSuppliesTables = new List<ExternalSuppliesTable>();
        public virtual IReadOnlyList<ExternalSuppliesTable> ExternalSuppliesTables => _externalSuppliesTables.ToList();
        public override double TotalBeforePriceChange => _sections.Sum(s => s.Total) + _externalSuppliesTables.Sum(t => t.Total);
        public override double Total => TotalBeforePriceChange;
        protected SuppliesTable() { }
        public SuppliesTable(BoqTable boqTable, StatementTableType type, BoqTableType boqTableType) : base(boqTable, type, boqTableType) { }
        public SuppliesTable(BoqTable boqTable, SuppliesTable previousTable, StatementTableType type, BoqTableType boqTableType) : base(boqTable, previousTable, type, boqTableType)
        {
            _externalSuppliesTables = previousTable.ExternalSuppliesTables.Select(table => new ExternalSuppliesTable(table)).ToList();
        }
    }
}
*/