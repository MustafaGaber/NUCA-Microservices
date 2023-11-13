using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Data.Boqs
{
    public class BoqRepository : Repository<Boq, long>, IBoqRepository
    {
        public BoqRepository(ProjectsDatabaseContext database)
           : base(database) { }

        public override Task<Boq?> Get(long id)
        {
            return database.Boqs
                .Include(b => b.Tables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .Include(b => b.Tables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Department)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
