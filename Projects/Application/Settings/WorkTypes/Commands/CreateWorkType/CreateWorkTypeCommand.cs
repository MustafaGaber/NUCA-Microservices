using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.CreateWorkType
{
    public class CreateWorkTypeCommand : ICreateWorkTypeCommand
    {
        private readonly IWorkTypeRepository _workTypeRepository;
        public CreateWorkTypeCommand(IWorkTypeRepository workTypeRepository)
        {
            _workTypeRepository = workTypeRepository;
        }
        public Task<WorkType> Execute(WorkTypeModel model)
        {
            return _workTypeRepository.Add(new WorkType(
                name: model.Name,
                valueAddedTaxPercent: model.ValueAddedTaxPercent,
                commercialIndustrialTaxPercent: model.CommercialIndustrialTaxPercent,
                selfEmploymentTaxPercent: model.SelfEmploymentTaxPercent
            ));
        }

    }
}
