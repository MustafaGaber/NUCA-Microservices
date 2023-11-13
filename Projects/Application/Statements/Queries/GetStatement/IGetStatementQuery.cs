
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.GetStatement
{
    public interface IGetStatementQuery
    {
        Task<Statement> Execute(long Id);
    }
}
