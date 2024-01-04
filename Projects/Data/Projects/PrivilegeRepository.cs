using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Queries.GetCurrentStatements;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Data.Projects
{
    public class PrivilegeRepository : Repository<Privilege>, IPrivilegeRepository
    {
        public PrivilegeRepository(ProjectsDatabaseContext database) : base(database)
        {
        }

        public Task<List<Privilege>> GetProjectPrivilegesForUser(long projectId, string userId)
        {
            return database.Set<Privilege>()
                .Where(p => p.ProjectId == projectId && p.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Privilege>> GetStatementPrivilegesForUser(long statementId, string userId)
        {
            var projectId = await database.Statements
                .Where(s => s.Id == statementId).Select(s => s.ProjectId).FirstOrDefaultAsync();
            var privileges = await database.Set<Privilege>()
                  .Where(p => p.ProjectId == projectId && p.UserId == userId)
                  .ToListAsync();
            return privileges;
        }
    }
}
