using NUCA.Projects.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface  ICompanyRepository : IRepository<Company, long>
    {
        public Task<bool> CompanyHasProjects(long id);
    }
}
