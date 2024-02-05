namespace NUCA.Projects.Application.Statements.Commands.DeleteStatement
{
    public interface IDeleteStatementCommand
    {
        Task Execute(long id);
    }
}
