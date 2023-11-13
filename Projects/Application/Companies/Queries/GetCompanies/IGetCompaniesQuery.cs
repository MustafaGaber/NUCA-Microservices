using NUCA.Projects.Application.Departments;
using System.Collections.Generic;

namespace NUCA.Projects.Application.Companies.Queries.GetCompanies
{
    public interface IGetCompaniesQuery
    {
        Task<List<GetShortCompanyModel>> Execute();
    }
}
