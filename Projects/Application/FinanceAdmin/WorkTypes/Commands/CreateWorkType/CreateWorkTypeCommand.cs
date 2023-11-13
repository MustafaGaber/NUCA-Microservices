using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.CreateWorkType
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
            return _workTypeRepository.Add(new WorkType(model.Name, model.ValueAddedTaxPercent));
        }

    }
}
