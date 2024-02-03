
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Domain.Entities.Projects;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Commands.ApproveProject
{
    public interface IApproveProjectCommand
    {
        Task<GetProjectModel> Execute(long projectId, ClaimsPrincipal user);
    }
}
