using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.WorkTypes.Queries.CanDeleteWorkType
{
    public class CanDeleteWorkTypeQuery : ICanDeleteWorkTypeQuery
    {
        private readonly IWorkTypeRepository _repository;
        public CanDeleteWorkTypeQuery(IWorkTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(int id)
        {
            var hasProjects = await _repository.WorkTypeHasProjects(id);
            return !hasProjects;
        }
    }
}
