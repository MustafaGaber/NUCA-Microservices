using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Data.Departments
{
    public class DepartmentRepository : Repository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository(ProjectsDatabaseContext database)
         : base(database) { }


        public async Task<bool> DepartmentHasUsers(int id)
        {
            int count = await database.Users.Include(u => u.Departments).Where(u => u.Departments.Select(d => d.Id).Contains(id)).CountAsync();
            return count > 0;
        }

        public async Task<bool> DepartmentHasProjects(int id)
        {
            int count = await database.Projects.Include(p => p.Department).Where(p => p.Department.Id == id).CountAsync();
            return count > 0;
        }

        public async Task<bool> DepartmentHasBoqSections(int id)
        {
            int count = await database.Set<BoqSection>()
                .Include(s => s.Department)
                .Where(s => s.Department.Id == id).CountAsync();
            return count > 0;
        }
    }
}
