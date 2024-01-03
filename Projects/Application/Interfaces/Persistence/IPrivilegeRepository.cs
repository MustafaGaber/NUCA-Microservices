using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IPrivilegeRepository: IRepository<Privilege>
    {
        public Task<List<Privilege>> GetProjectPrivilegesForUser(long projectId, string userId);

    }
}
