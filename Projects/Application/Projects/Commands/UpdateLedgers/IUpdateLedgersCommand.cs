using NUCA.Projects.Application.Projects.Models;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Commands.UpdateLedgers
{
    public interface IUpdateLedgersCommand
    {
        Task<GetProjectLedgersModel> Execute(long projectId, UpdateLedgersModel model, ClaimsPrincipal user);
    }
}
