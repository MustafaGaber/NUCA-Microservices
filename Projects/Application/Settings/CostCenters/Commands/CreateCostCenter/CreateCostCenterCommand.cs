using NUCA.Projects.Application.Settings.CostCenters.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.CostCenters.Commands.CreateCostCenter
{
    public class CreateCostCenterCommand : ICreateCostCenterCommand
    {
        private readonly ICostCenterRepository _costCenterRepository;
        public CreateCostCenterCommand(ICostCenterRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }
        public async Task<GetCostCenterModel> Execute(CostCenterModel model)
        {
            var parent = model.ParentId == null ? null : await _costCenterRepository.Get((long)model.ParentId!);
            var costCenter = await _costCenterRepository.Add(new CostCenter(model.Name, parent));
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
