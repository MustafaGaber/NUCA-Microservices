using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.UpdateWorkType
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
            WorkType? workType = await _workTypeRepository.Get(id);
            if (workType == null)
            {
                throw new InvalidOperationException();
            }
            workType.Update(model.Name, model.ValueAddedTaxPercent);
            await _workTypeRepository.Update(workType);
            return workType;
        }
    }
}
