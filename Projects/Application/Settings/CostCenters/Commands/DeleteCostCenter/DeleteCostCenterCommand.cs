using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.CostCenters.Commands.DeleteCostCenter
{
    public class DeleteCostCenterCommand : IDeleteCostCenterCommand
    {
        private readonly ICostCenterRepository _costCenterRepository;
        public DeleteCostCenterCommand(ICostCenterRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }
        public async Task Execute(int id)
        {
            bool hasProjects = await _costCenterRepository.CostCenterHasProjects(id);
            if (hasProjects)
            {
                throw new InvalidOperationException("CostCenter has projects");
            }
            bool hasChildren = await _costCenterRepository.HasChildren(id);
            if (hasChildren)
            {
                throw new InvalidOperationException("CostCenter has children");
            }
            await _costCenterRepository.Delete(id);
        }
    }
}
