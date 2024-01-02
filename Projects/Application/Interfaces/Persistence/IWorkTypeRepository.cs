using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IWorkTypeRepository : IRepository<WorkType>
    {
        public Task<bool> WorkTypeHasProjects(int id);
    }
}
