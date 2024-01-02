using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Boqs.Queries.GetBoq;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Data.Boqs
{
    public class BoqRepository : Repository<Boq>, IBoqRepository
    {
        private IQueryable<Boq> boqQuery;
        public BoqRepository(ProjectsDatabaseContext database)
           : base(database)
        {

            boqQuery = database.Boqs
                .Include(b => b.Tables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .Include(b => b.Tables)
                .ThenInclude(t => t.Sections)
                //.ThenInclude(s => s.Department)
                .AsSplitQuery();
        }

        override
        public Task<Boq?> Get(long id)
        {
            return boqQuery.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<Boq?> GetByProjectId(long projectId)
        {
            return boqQuery.FirstOrDefaultAsync(u => u.ProjectId == projectId);
        }
    }
}
