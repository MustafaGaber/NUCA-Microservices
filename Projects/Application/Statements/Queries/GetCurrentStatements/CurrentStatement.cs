using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.GetCurrentStatements
{
    public class CurrentStatement
    {
        public long Id { get; init; }
        public long ProjectId { get; init; }
        public string ProjectName { get; init; }
        public int Index { get; init; }
        public DateOnly WorksDate { get; init; }
        public DateOnly SubmissionDate { get; init; }
        public bool Final { get; init; }
        public StatementState State { get; init; }
    }
}
