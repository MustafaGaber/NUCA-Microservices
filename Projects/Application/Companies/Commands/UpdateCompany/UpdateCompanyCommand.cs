using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IUpdateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public UpdateCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<Company> Execute(long id, CompanyModel model)
        {
            Company? company = await _companyRepository.Get(id);
            if (company == null)
            {
                throw new InvalidOperationException();
            }
            company.Update(
                name: model.Name,
                address: model.Address,
                phone: model.Phone,
                fax: model.Fax,
                commercialRegister: model.CommercialRegister,
                taxCard: model.TaxCard,
                electronicInvoice: model.ElectronicInvoice,
                commercialIndustrialTaxFree: model.CommercialIndustrialTaxFree);
            await _companyRepository.Update(company);
            return company;
        }
    }
}
