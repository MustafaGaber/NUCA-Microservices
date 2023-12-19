using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        public Task<bool> DepartmentHasUsers(string id);
        public Task<bool> DepartmentHasProjects(string id);
        public Task<bool> DepartmentHasBoqSections(string id);

    }
}
