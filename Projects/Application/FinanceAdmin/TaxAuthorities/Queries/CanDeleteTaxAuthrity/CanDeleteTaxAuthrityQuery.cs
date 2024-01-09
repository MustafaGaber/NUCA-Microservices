using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Queries.CanDeleteTaxAuthority
{
    public class CanDeleteTaxAuthorityQuery : ICanDeleteTaxAuthorityQuery
    {
        private readonly ITaxAuthorityRepository _repository;
        public CanDeleteTaxAuthorityQuery(ITaxAuthorityRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(int id)
        {
            var hasProjects = await _repository.TaxAuthorityHasProjects(id);
            return !hasProjects;
        }
    }
}
