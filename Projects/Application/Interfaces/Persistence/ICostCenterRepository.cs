using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface ICostCenterRepository: IRepository<CostCenter>
    {
        public Task<bool> CostCenterHasProjects(long id);

    }
}
