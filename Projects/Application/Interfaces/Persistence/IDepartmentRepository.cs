using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        public Task<bool> DepartmentHasUsers(int id);
        public Task<bool> DepartmentHasProjects(int id);
        public Task<bool> DepartmentHasBoqSections(int id);

    }
}
