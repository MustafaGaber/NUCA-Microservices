using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.GetCurrentStatements
{
    public class CurrentStatement
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int Index { get; set; }
        public DateOnly WorksDate { get; set; }
        public DateOnly SubmissionDate { get; set; }
        public bool Final { get; set; }
        public StatementState State { get; set; }
    }
}
