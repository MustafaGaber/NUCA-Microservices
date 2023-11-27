
using NUCA.Projects.Application.Statements.Models;

namespace NUCA.Projects.Application.Statements.Queries.GetStatement
{
    public interface IGetStatementQuery
    {
        Task<StatementModel> Execute(long Id);
    }
}
