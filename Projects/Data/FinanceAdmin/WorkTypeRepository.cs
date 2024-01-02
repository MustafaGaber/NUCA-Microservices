using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Data.FinanceAdmin
{
    public class WorkTypeRepository : Repository<WorkType>, IWorkTypeRepository
    {
        public WorkTypeRepository(ProjectsDatabaseContext database)
          : base(database) { }

        public async Task<bool> WorkTypeHasProjects(int id)
        {
            int count = await database.Projects.Include(p => p.Type).Where(p => p.Type.Id == id).CountAsync();
            // Todo: boq items;
            return count > 0;
        }

    }
}
