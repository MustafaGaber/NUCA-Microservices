using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Data.Settings
{
    public class AwardTypeRepository : Repository<AwardType>, IAwardTypeRepository
    {
        public AwardTypeRepository(ProjectsDatabaseContext database)
          : base(database) { }

        public async Task<bool> AwardTypeHasProjects(long id)
        {
            int count = await database.Projects
                .Include(p => p.AwardType)
                .Where(p => p.AwardType != null && p.AwardType.Id == id)
                .CountAsync();
            return count > 0;
        }

    }
}
