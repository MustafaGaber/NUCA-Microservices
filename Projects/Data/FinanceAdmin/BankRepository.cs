using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Data.FinanceAdmin
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(ProjectsDatabaseContext database)
          : base(database) { }

        public async Task<bool> BankHasProjects(long id)
        {
            int count = await database.Projects
                .Include(p => p.Bank)
                .Where(p => p.Bank != null && p.Bank.Id == id)
                .CountAsync();
            return count > 0;
        }

    }
}
