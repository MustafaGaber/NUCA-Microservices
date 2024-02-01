using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NUCA.Projects.Data.Projects
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectsDatabaseContext database)
         : base(database) { }

        public override Task<List<Project>> All()
        {
            return ProjectsQuery.ToListAsync();
        }

        public override Task<List<Project>> Find(Expression<Func<Project, bool>> predicate)
        {
            return ProjectsQuery.Where(predicate).ToListAsync();
        }
        public override Task<Project?> Get(long id)
        {
            return ProjectsQuery.FirstOrDefaultAsync(d => d.Id == id);
        }

        public override Task<List<T>> Select<T>(Expression<Func<Project, T>> selector)
        {
            return ProjectsQuery.Select(selector).ToListAsync();
        }

        private IQueryable<Project> ProjectsQuery =>
            database.Projects
                .Include(p => p.Company)
                // .Include(p => p.Department)
                .Include(p => p.WorkType)
                .Include(p => p.AwardType)
                .Include(p => p.CostCenter)
                .Include(p => p.Classifications)
                .Include(p => p.MainBank)
                .Include(p => p.BankBranch)
                .Include(p => p.TaxAuthority)
                .Include(p => p.ModifiedEndDates);
    }
}
