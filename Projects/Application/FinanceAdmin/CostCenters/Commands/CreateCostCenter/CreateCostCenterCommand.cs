using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.CreateCostCenter
{
    public class CreateCostCenterCommand : ICreateCostCenterCommand
    {
        private readonly ICostCenterRepository _costCenterRepository;
        public CreateCostCenterCommand(ICostCenterRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }
        public async Task<CostCenter> Execute(CostCenterModel model)
        {
            var parent = model.ParentId == null ? null : await _costCenterRepository.Get((long)model.ParentId!);
            var costCenter = await _costCenterRepository.Add(new CostCenter(model.Name, parent));
            return costCenter;
        }

    }
}
