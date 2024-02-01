namespace NUCA.Projects.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementModel
    {
        public DateOnly WorksDate { get; init; }
        public int? Index { get; init; }
        public bool IsFinal { get; init; }

    }
}
