using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Data.Companies
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ProjectsDatabaseContext database)
          : base(database) { }

        public async Task<bool> CompanyHasProjects(long id)
        {
            int count = await database.Projects.Include(p => p.Company).Where(p => p.Company.Id == id).CountAsync() ;
            return count > 0;
        }

    }
}
