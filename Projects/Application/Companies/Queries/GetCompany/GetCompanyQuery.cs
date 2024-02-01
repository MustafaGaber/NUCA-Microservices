using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQuery : IGetCompanyQuery
    {
        private readonly ICompanyRepository _repository;

        public GetCompanyQuery(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCompanyModel?> Execute(long id)
        {
            var company = await _repository.Get(id);
            return company != null ? new GetCompanyModel
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Phone = company.Phone,
                Fax = company.Fax,
                CommercialRegister = company.CommercialRegister,
                TaxCard = company.TaxCard,
                ElectronicInvoice = company.ElectronicInvoice,
                CommercialIndustrialTaxFree = company.CommercialIndustrialTaxFree
            }: null;
        }

    }
}
