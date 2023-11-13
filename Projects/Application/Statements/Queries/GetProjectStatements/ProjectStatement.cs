using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.GetProjectStatements
{
    public class ProjectStatement
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public DateOnly WorksDate { get; set; }
        public DateOnly SubmissionDate { get; set; }
        public bool Final { get; set; }
        public StatementState State { get; set; }
    }
}
