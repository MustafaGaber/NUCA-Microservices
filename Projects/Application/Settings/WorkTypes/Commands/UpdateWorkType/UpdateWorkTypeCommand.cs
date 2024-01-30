using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.UpdateWorkType
{
    public class UpdateWorkTypeCommand : IUpdateWorkTypeCommand
    {
        private readonly IWorkTypeRepository _workTypeRepository;
        public UpdateWorkTypeCommand(IWorkTypeRepository workTypeRepository)
        {
            _workTypeRepository = workTypeRepository;
        }
        public async Task<WorkType> Execute(int id, WorkTypeModel model)
        {
            WorkType? workType = await _workTypeRepository.Get(id) ?? throw new InvalidOperationException();
            workType.Update(
                name: model.Name,
                valueAddedTaxPercent: model.ValueAddedTaxPercent,
                commercialIndustrialTaxPercent: model.CommercialIndustrialTaxPercent,
                selfEmploymentTaxPercent: model.SelfEmploymentTaxPercent
            );
            await _workTypeRepository.Update(workType);
            return workType;
        }
    }
}
