using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : ICreateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public Task<Company> Execute(CompanyModel model)
        {
            return _companyRepository.Add(new Company(
                name: model.Name,
                address: model.Address,
                phone: model.Phone,
                fax: model.Fax,
                commercialRegister: model.CommercialRegister,
                taxCard: model.TaxCard,
                electronicInvoice: model.ElectronicInvoice,
                commercialIndustrialTaxFree: model.CommercialIndustrialTaxFree
                ));
        }

    }
}
