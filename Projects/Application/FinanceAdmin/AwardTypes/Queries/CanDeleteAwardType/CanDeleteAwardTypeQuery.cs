using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Queries.CanDeleteAwardType
{
    public class CanDeleteAwardTypeQuery : ICanDeleteAwardTypeQuery
    {
        private readonly IAwardTypeRepository _repository;
        public CanDeleteAwardTypeQuery(IAwardTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(int id)
        {
            var hasProjects = await _repository.AwardTypeHasProjects(id);
            return !hasProjects;
        }
    }
}
