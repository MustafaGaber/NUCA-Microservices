
using NUCA.Projects.Application.Departments;

namespace NUCA.Projects.Application.Companies.Queries.GetCompany
{
    public interface IGetCompanyQuery
    {
        Task<GetCompanyModel?> Execute(long id);
    }
}
