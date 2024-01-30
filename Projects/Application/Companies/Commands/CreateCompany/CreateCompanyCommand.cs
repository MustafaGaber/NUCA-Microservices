using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : ICreateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ITaxAuthorityRepository _taxAuthorityRepository;
        public CreateCompanyCommand(ICompanyRepository companyRepository, ITaxAuthorityRepository taxAuthorityRepository)
        {
            _companyRepository = companyRepository;
            _taxAuthorityRepository = taxAuthorityRepository;
        }
        public async Task<Company> Execute(CompanyModel model)
        {
            TaxAuthority? taxAuthority = await _taxAuthorityRepository.Get(model.TaxAuthorityId);
            var company = await _companyRepository.Add(new Company(
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
           ));
            return company;
        }

    }
}
