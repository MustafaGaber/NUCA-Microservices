using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Companies.Queries.CanDeleteCompany
{
    public interface ICanDeleteCompanyQuery
    {
         Task<bool> Execute(long id);
    }
}
