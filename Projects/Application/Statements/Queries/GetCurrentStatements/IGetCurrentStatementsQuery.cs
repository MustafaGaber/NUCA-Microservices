using NUCA.Projects.Application.Statements.Queries.GetCurrentStatements;

namespace NUCA.Projects.Application.Statements.Queries.GetUserStatements
{
    public interface IGetCurrentStatementsQuery
    {
        public Task<List<CurrentStatement>> Execute(long userId);
    }
}
