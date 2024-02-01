

using NUCA.Projects.Application.Statements.Models;
using System.Security.Claims;

namespace NUCA.Projects.Application.Statements.Commands.TechnicalOfficeSubmit
{
    public interface ITechnicalOfficeSubmitCommand
    {
       public Task<StatementModel> Execute(long id, TechnicalOfficeSubmitModel model, ClaimsPrincipal user);
    }
}
