using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settings.WorkTypes.Queries;
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
        public async Task<GetWorkTypeModel> Execute(WorkTypeModel model)
        {
            var workType = await _workTypeRepository.Add(new WorkType(
                name: model.Name,
                valueAddedTaxPercent: model.ValueAddedTaxPercent,
                commercialIndustrialTaxPercent: model.CommercialIndustrialTaxPercent,
                selfEmploymentTaxPercent: model.SelfEmploymentTaxPercent
            ));
            return new GetWorkTypeModel
            {
                Id = workType.Id,
                Name = workType.Name,
                ValueAddedTaxPercent = workType.ValueAddedTaxPercent,
                CommercialIndustrialTaxPercent = workType.CommercialIndustrialTaxPercent,
                SelfEmploymentTaxPercent = workType.SelfEmploymentTaxPercent
            };
        }

    }
}
