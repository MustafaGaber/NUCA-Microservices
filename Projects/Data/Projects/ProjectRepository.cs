using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NUCA.Projects.Data.Projects
{
    public class ProjectRepository : Repository<Project, long>, IProjectRepository
    {
        public ProjectRepository(ProjectsDatabaseContext database)
         : base(database) { }

        public override Task<List<Project>> All()
        {
            return database.Projects
                .Include(p => p.Company)
                //.Include(p => p.Department)
                .Include(p => p.Type)
                .Include(p => p.AwardType)
                .Include(p => p.ModifiedEndDates)
                .ToListAsync();
        }

        public override Task<List<Project>> Find(Expression<Func<Project, bool>> predicate)
        {
            return database.Projects
                .Include(p => p.Company)
                //.Include(p => p.Department)
                .Include(p => p.Type)
                .Include(p => p.AwardType)
                .Include(p => p.ModifiedEndDates)
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();
        }
        public override Task<Project?> Get(long id)
        {
            return database.Projects
                .Include(p => p.Company)
                //.Include(p => p.Department)
                .Include(p => p.Type)
                .Include(p => p.AwardType)
                .Include(p => p.ModifiedEndDates)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public override Task<List<T>> Select<T>(Expression<Func<Project, T>> selector)
        {
            return database.Projects
                .Include(p => p.Company)
               // .Include(p => p.Department)
                .Include(p => p.Type)
                .Include(p => p.AwardType)
                .Include(p => p.ModifiedEndDates)
                .Select(selector).ToListAsync();
        }
    }
}
