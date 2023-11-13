/*using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class WorksTable : StatementTable
    {
        protected WorksTable() { }
        public WorksTable(BoqTable boqTable) : base(boqTable)
        {

        }
        public WorksTable(BoqTable boqTable, WorksTable previousTable) : base(boqTable, previousTable)
        {

        }

        public override double Total => _sections.Sum(s => s.Total);

    }
}
*/