

using System.Security.Claims;

namespace NUCA.Projects.Application.Statements.Commands.TechnicalOfficeSubmit
{
    public interface ITechnicalOfficeSubmitCommand
    {
        Task Execute(long id, TechnicalOfficeSubmitModel model, ClaimsPrincipal user);
    }
}
