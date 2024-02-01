using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.Banks.Queries.CanDeleteBranch
{
    public class CanDeleteBranchQuery: ICanDeleteBranchQuery
    {
        private readonly IBankRepository _repository;
        public CanDeleteBranchQuery(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(long id)
        {
            var hasProjects = await _repository.BranchHasProjects(id);
            return !hasProjects;
        }
    }
}
