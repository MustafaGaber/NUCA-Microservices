
using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<GetProjectWithLedgersModel> GetProjectWithLedgers(long id);
        Task<ProjectWithLedgers> GetProjectLedgers(long id);
    }
}
