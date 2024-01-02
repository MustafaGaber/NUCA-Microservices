using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IAwardTypeRepository : IRepository<AwardType>
    {
        public Task<bool> AwardTypeHasProjects(int id);
    }
}
