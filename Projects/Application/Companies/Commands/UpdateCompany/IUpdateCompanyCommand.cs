using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Commands.UpdateCompany
{
    public interface IUpdateCompanyCommand
    {
        Task<Company> Execute(long id, CompanyModel model);
    }
}
