using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.TaxAuthorities.Commands.CreateTaxAuthority
{
    public class CreateTaxAuthorityCommand : ICreateTaxAuthorityCommand
    {
        private readonly ITaxAuthorityRepository _taxAuthorityRepository;
        public CreateTaxAuthorityCommand(ITaxAuthorityRepository taxAuthorityRepository)
        {
            _taxAuthorityRepository = taxAuthorityRepository;
        }
        public Task<TaxAuthority> Execute(TaxAuthorityModel model)
        {
            return _taxAuthorityRepository.Add(new TaxAuthority(model.Name, model.Address));
        }

    }
}
