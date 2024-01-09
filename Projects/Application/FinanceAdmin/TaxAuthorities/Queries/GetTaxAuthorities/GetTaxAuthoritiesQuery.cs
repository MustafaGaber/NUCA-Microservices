using NUCA.Projects.Application.Interfaces.Persistence;


namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Queries.GetTaxAuthorities
{
    public class GetTaxAuthoritiesQuery : IGetTaxAuthoritiesQuery
    {

        private readonly ITaxAuthorityRepository _repository;

        public GetTaxAuthoritiesQuery(ITaxAuthorityRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetTaxAuthorityModel>> Execute()
        {
            return _repository.Select(taxAuthority => new GetTaxAuthorityModel
            {
                Id = taxAuthority.Id,
                Name = taxAuthority.Name,
            });
        }
    }
}
