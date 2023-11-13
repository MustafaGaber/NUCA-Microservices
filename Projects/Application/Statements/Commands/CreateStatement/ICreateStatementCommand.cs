namespace NUCA.Projects.Application.Statements.Commands.CreateStatement
{
    public interface ICreateStatementCommand
    {
        public Task<long> Execute(long projectId, CreateStatementModel statement);
    }
}
