using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Commands.CreateAwardType
{
    public class CreateAwardTypeCommand : ICreateAwardTypeCommand
    {
        private readonly IAwardTypeRepository _awardTypeRepository;
        public CreateAwardTypeCommand(IAwardTypeRepository awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }
        public Task<AwardType> Execute(AwardTypeModel model)
        {
            return _awardTypeRepository.Add(new AwardType(model.Name, model.EstimatedPrice));
        }

    }
}
