

using NUCA.Projects.Domain.Entities.Statements;
using System.Security.Claims;

namespace NUCA.Projects.Application.Statements.Commands.TechnicalOfficeSubmit
{
    public interface ITechnicalOfficeSubmitCommand
    {
       public Task<Statement> Execute(long id, TechnicalOfficeSubmitModel model, ClaimsPrincipal user);
    }
}
