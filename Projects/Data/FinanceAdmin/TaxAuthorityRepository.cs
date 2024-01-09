using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Data.FinanceAdmin
{
    public class TaxAuthorityRepository : Repository<TaxAuthority>, ITaxAuthorityRepository
    {
        public TaxAuthorityRepository(ProjectsDatabaseContext database)
          : base(database) { }

        public async Task<bool> TaxAuthorityHasProjects(long id)
        {
            int count = await database.Projects
                .Include(p => p.TaxAuthority)
                .Where(p => p.TaxAuthority != null && p.TaxAuthority.Id == id)
                .CountAsync();
            return count > 0;
        }

    }
}
