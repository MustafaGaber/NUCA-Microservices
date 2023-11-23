
using NUCA.Projects.Application.Statements.Models;

namespace NUCA.Projects.Application.Statements.Queries.PrintStatement
{
    public interface IPrintStatementQuery
    {
        Task<PrintStatementModel> Execute(long Id);

    }
}
