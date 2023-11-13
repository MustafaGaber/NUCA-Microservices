using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Commands.DeleteAwardType
{
    public class DeleteAwardTypeCommand : IDeleteAwardTypeCommand
    {
        private readonly IAwardTypeRepository _awardTypeRepository;
        public DeleteAwardTypeCommand(IAwardTypeRepository awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }
        public async Task Execute(int id)
        {
            bool hasProjects = await _awardTypeRepository.AwardTypeHasProjects(id);
            if (!hasProjects)
            {
                await _awardTypeRepository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("AwardType has projects");
            }
        }
    }
}
