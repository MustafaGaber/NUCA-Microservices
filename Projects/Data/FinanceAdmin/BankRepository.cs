using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Data.FinanceAdmin
{
    public class BankRepository : Repository<MainBank>, IBankRepository
    {
        public BankRepository(ProjectsDatabaseContext database)
          : base(database) { }

        public Task<List<BankBranch>> AllBranches()
        {
            return database.BankBranches.ToListAsync();
        }
        public async Task<BankBranch?> GetBranch(long id)
        {
            var branch = await database.Set<BankBranch>().FindAsync(id);
            return branch;
        }

        public async Task<BankBranch> AddBranch(BankBranch branch)
        {
            BankBranch item = database.Set<BankBranch>().Add(branch).Entity;
            await database.SaveChangesAsync();
            return item;
        }

        public async Task<bool> BranchHasProjects(long id)
        {
            int count = await database.Projects
              .Include(p => p.BankBranch)
              .Where(p => p.BankBranch != null && p.BankBranch.Id == id)
              .CountAsync();
            return count > 0;
        }

        public async Task DeleteBranch(long id)
        {
            var entity = await database.Set<BankBranch>().FindAsync(id);
            if (entity == null) return;
            database.Set<BankBranch>().Remove(entity);
            await database.SaveChangesAsync();
        }

        public async Task<bool> MainBankHasBranches(long id)
        {
            int count = await database.BankBranches
               .Where(b => b.MainBankId == id)
               .CountAsync();
            return count > 0;
        }

        public async Task<bool> MainBankHasProjects(long id)
        {
            int count = await database.Projects
                .Include(p => p.MainBank)
                .Where(p => p.MainBank != null && p.MainBank.Id == id)
                .CountAsync();
            return count > 0;
        }

        public async Task<BankBranch> UpdateBranch(BankBranch branch)
        {
            BankBranch item = database.Set<BankBranch>().Update(branch).Entity;
            await database.SaveChangesAsync();
            return item;
        }

        public Task<List<GetBankBranchModel>> GetMainBankBranches(long id)
        {
            return database.BankBranches
               .Where(b => b.MainBankId == id)
               .Select(b => new GetBankBranchModel
               {
                   Id = b.Id,
                   Name = b.Name,
                   MainBankId = b.MainBankId
               }).ToListAsync();
        }
    }
}
