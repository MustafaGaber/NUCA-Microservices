/*using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class SuppliesTable : StatementTable
    {
        protected SuppliesTable() { }
        public SuppliesTable(BoqTable boqTable) : base(boqTable)
        {

        }
        public SuppliesTable(BoqTable boqTable, SuppliesTable previousTable) : base(boqTable, previousTable)
        {

        }

        public override double Total => _sections.Sum(s => s.Total) * (100 + PriceChangePercent) / 100;


    }
}
*/