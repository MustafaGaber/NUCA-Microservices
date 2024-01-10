using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.DeleteCostCenter
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
            if (!hasProjects)
            {
                await _costCenterRepository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("CostCenter has projects");
            }
        }
    }
}
