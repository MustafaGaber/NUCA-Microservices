using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IWorkTypeRepository : IRepository<WorkType, int>
    {
        public Task<bool> WorkTypeHasProjects(int id);
    }
}
