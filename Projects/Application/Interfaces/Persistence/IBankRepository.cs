using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IBankRepository : IRepository<MainBank>
    {
        public Task<bool> BankHasProjects(int id);
    }
}
