using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.CreateProject
{
    public interface ICreateProjectCommand
    {
        Task<Project> Execute(ProjectModel model);
    }
}
