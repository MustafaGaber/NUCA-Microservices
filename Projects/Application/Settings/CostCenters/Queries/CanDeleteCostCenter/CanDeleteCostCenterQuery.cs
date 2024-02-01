using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.CostCenters.Queries.CanDeleteCostCenter
{
    public class CanDeleteCostCenterQuery : ICanDeleteCostCenterQuery
    {
        private readonly ICostCenterRepository _repository;
        public CanDeleteCostCenterQuery(ICostCenterRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(int id)
        {
            var hasProjects = await _repository.CostCenterHasProjects(id);
            return !hasProjects;
        }
    }
}
