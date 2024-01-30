using NUCA.Projects.Application.Settings.CostCenters.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.CostCenters.Commands.UpdateCostCenter
{
    public class UpdateCostCenterCommand : IUpdateCostCenterCommand
    {
        private readonly ICostCenterRepository _costCenterRepository;
        public UpdateCostCenterCommand(ICostCenterRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }
        public async Task<GetCostCenterModel> Execute(int id, CostCenterModel model)
        {
            var parent = model.ParentId == null ? null : await _costCenterRepository.Get((long)model.ParentId!);
            // Todo: validate that parent
            if (parent != null && parent.FullPath.Split('/').Contains(id.ToString()))
            {
                throw new InvalidOperationException("Parent is a child for cost center");
            }
            CostCenter? costCenter = await _costCenterRepository.Get(id) ?? throw new InvalidOperationException();
            costCenter.Update(model.Name, parent);
            await _costCenterRepository.Update(costCenter);
            return new GetCostCenterModel()
            {
                Id = costCenter.Id,
                Name = costCenter.Name,
                ParentId = costCenter.ParentId,
                ParentFullPath = costCenter.ParentFullPath
            };
        }
    }
}
