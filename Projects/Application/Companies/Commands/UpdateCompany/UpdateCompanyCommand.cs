using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IUpdateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ITaxAuthorityRepository _taxAuthorityRepository;
        public UpdateCompanyCommand(ICompanyRepository companyRepository, ITaxAuthorityRepository taxAuthorityRepository)
        {
            _companyRepository = companyRepository;
            _taxAuthorityRepository = taxAuthorityRepository;
        }
        public async Task<Company> Execute(long id, CompanyModel model)
        {
            Company? company = await _companyRepository.Get(id) ?? throw new InvalidOperationException();
            TaxAuthority? taxAuthority = await _taxAuthorityRepository.Get(model.TaxAuthorityId);

            company.Update(
                name: model.Name,
                type: model.Type,
                address: model.Address,
                phone: model.Phone,
                fax: model.Fax,
                commercialRegister: model.CommercialRegister,
                taxCard: model.TaxCard,
                taxFile: model.TaxFile,
                electronicInvoice: model.ElectronicInvoice,
                commercialIndustrialTaxFree: model.CommercialIndustrialTaxFree,
                taxAuthority: taxAuthority
            );
            await _companyRepository.Update(company);
            return company;
        }
    }
}
