using NUCA.Projects.Application.FinanceAdmin.Banks.Queries;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IBankRepository : IRepository<MainBank>
    {
        Task<bool> MainBankHasProjects(long id);
        Task<bool> MainBankHasBranches(long id);
        Task<bool> BranchHasProjects(long id);
        Task<List<BankBranch>> AllBranches();
        Task<BankBranch?> GetBranch(long id);
        Task<BankBranch> AddBranch(BankBranch branch);
        Task<BankBranch> UpdateBranch(BankBranch branch);
        Task DeleteBranch(long id);
        Task<List<GetBankBranchModel>> GetMainBankBranches(long id);
    }
}
