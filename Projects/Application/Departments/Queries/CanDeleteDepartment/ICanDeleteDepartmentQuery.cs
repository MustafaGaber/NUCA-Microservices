using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Departments.Queries.CanDeleteDepartment
{
    public interface ICanDeleteDepartmentQuery
    {
        public Task<bool> Execute(int id);
    }
}
