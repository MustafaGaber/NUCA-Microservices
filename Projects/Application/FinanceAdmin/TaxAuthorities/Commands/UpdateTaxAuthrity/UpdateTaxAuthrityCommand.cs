using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Commands.UpdateTaxAuthority
{
    public class UpdateTaxAuthorityCommand : IUpdateTaxAuthorityCommand
    {
        private readonly ITaxAuthorityRepository _taxAuthorityRepository;
        public UpdateTaxAuthorityCommand(ITaxAuthorityRepository taxAuthorityRepository)
        {
            _taxAuthorityRepository = taxAuthorityRepository;
        }
        public async Task<TaxAuthority> Execute(int id, TaxAuthorityModel model)
        {
            TaxAuthority? taxAuthority = await _taxAuthorityRepository.Get(id) ?? throw new InvalidOperationException();
            taxAuthority.Update(model.Name, model.EstimatedPrice);
            await _taxAuthorityRepository.Update(taxAuthority);
            return taxAuthority;
        }
    }
}
