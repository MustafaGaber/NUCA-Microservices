using NUCA.Projects.Application.Boqs.Commands.CreateBoq;
using NUCA.Projects.Application.Boqs.Models;
using System.Security.Claims;

namespace NUCA.Projects.Application.Boqs.Commands.ApproveBoq
{
    public interface IApproveBoqCommand
    {
        Task<BoqModel> Execute(long boqId, ClaimsPrincipal user);
    }
}
