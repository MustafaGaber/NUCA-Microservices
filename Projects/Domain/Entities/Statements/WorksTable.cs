/*using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class WorksTable : StatementTable
    {
        public override double TotalBeforePriceChange => _sections.Sum(s => s.Total);
        public override double Total =>
            TotalBeforePriceChange * (100 + PriceChangePercent) / 100;

        protected WorksTable() { }
        public WorksTable(BoqTable boqTable, StatementTableType type, BoqTableType boqTableType) : base(boqTable, type, boqTableType) { }
        public WorksTable(BoqTable boqTable, WorksTable previousTable, StatementTableType type, BoqTableType boqTableType) : base(boqTable, previousTable, type, boqTableType) { }
    }
}
*/