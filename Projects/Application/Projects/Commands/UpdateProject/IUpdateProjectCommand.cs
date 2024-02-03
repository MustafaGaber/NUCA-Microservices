using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.UpdateProject
{
    public interface IUpdateProjectCommand
    {
        Task<Project> Execute(long id, ProjectModel model);
    }
}
