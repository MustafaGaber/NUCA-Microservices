using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Shared.Constants;
using NUCA.Projects.Shared.Extensions;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Commands.ApproveProject
{
    public class ApproveProjectCommand : IApproveProjectCommand
    {
        private readonly IProjectRepository _projectRepository;

        public ApproveProjectCommand(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<GetProjectModel> Execute(long projectId, ClaimsPrincipal user)
        {
            if (user.Id() == null) throw new UnauthorizedAccessException();
            if (!user.HasPermission(Permissions.Revision)) throw new UnauthorizedAccessException();
            Project? project = await _projectRepository.Get(projectId);
            if (project == null || project.Status < ProjectStatus.Awarded)
            {
                throw new InvalidOperationException();
            }
            project.Approve(user.Id()!);
            await _projectRepository.Update(project);
            return GetProjectModel.FromProject(project, false);
        }
    }
}
