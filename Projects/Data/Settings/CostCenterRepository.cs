using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Data.Settings
{
    public class CostCenterRepository : Repository<CostCenter>, ICostCenterRepository
    {
        public CostCenterRepository(ProjectsDatabaseContext database) : base(database){ }

        public async Task<bool> CostCenterHasProjects(long id)
        {
            int count = await database.Projects
                .Include(p => p.CostCenter)
                .Where(p => p.CostCenter != null && p.CostCenter.Id == id)
                .CountAsync();
            return count > 0;
        }

        public async Task<bool> HasChildren(long id)
        {
            int count = await database.CostCenters
               .Where(c => c.ParentId == id)
               .CountAsync();
            return count > 0;
        }
    }
}
