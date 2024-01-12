using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.CanDeleteMainBank
{
    public class CanDeleteMainBankQuery : ICanDeleteMainBankQuery
    {
        private readonly IBankRepository _repository;
        public CanDeleteMainBankQuery(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(long id)
        {
            var hasBranches = await _repository.MainBankHasBranches(id);
            if (hasBranches) return false;
            var hasProjects = await _repository.MainBankHasProjects(id);
            return !hasProjects;
        }
    }
}
