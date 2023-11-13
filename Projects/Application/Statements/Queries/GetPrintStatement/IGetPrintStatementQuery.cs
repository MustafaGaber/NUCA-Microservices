
using NUCA.Projects.Application.Statements.Models;

namespace NUCA.Projects.Application.Statements.Queries.GetPrintStatement
{
    public interface IGetPrintStatementQuery
    {
        Task<PrintStatementModel> Execute(long Id);

    }
}
