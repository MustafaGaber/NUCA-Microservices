using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Data.Projects
{
    public class PrivilegeRepository : Repository<Privilege>, IPrivilegeRepository
    {
        public PrivilegeRepository(ProjectsDatabaseContext database) : base(database)
        {
        }
    }
}
