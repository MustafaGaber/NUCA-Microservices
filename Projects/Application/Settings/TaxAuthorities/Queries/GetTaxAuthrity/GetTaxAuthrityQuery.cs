using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.TaxAuthorities.Queries.GetTaxAuthority
{
    public class GetTaxAuthorityQuery : IGetTaxAuthorityQuery
    {
        private readonly ITaxAuthorityRepository _repository;

        public GetTaxAuthorityQuery(ITaxAuthorityRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTaxAuthorityModel?> Execute(int id)
        {
            var taxAuthority = await _repository.Get(id);
            return taxAuthority != null ? new GetTaxAuthorityModel
            {
                Id = taxAuthority.Id,
                Name = taxAuthority.Name,
                Address = taxAuthority.Address,
            } : null;
        }

    }
}
