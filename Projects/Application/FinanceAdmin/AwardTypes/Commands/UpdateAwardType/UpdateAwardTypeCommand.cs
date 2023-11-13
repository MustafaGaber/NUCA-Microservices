using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Commands.UpdateAwardType
{
    public class UpdateAwardTypeCommand : IUpdateAwardTypeCommand
    {
        private readonly IAwardTypeRepository _awardTypeRepository;
        public UpdateAwardTypeCommand(IAwardTypeRepository awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }
        public async Task<AwardType> Execute(int id, AwardTypeModel model)
        {
            AwardType? awardType = await _awardTypeRepository.Get(id);
            if (awardType == null)
            {
                throw new InvalidOperationException();
            }
            awardType.Update(model.Name, model.EstimatedPrice);
            await _awardTypeRepository.Update(awardType);
            return awardType;
        }
    }
}
