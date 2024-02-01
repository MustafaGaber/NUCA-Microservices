using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Data.Departments
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ProjectsDatabaseContext database)
         : base(database) { }


        public async Task<bool> DepartmentHasUsers(string id)
        {
            /* int count = await database.Users.Include(u => u.ExecutionDepartments).Where(u => u.ExecutionDepartments.Select(d => d.Id).Contains(id)).CountAsync();
             return count > 0;*/
            return true;
        }

        public async Task<bool> DepartmentHasProjects(string id)
        {
            int count = await database.Projects.Where(p => p.DepartmentId == id).CountAsync();
            return count > 0;
        }

        public async Task<bool> DepartmentHasBoqSections(string id)
        {
            return true;
           /* int count = await database.Set<BoqSection>()
                .Include(s => s.Department)
                .Where(s => s.Department.Id == id).CountAsync();
            return count > 0;*/
        }
    }
}
