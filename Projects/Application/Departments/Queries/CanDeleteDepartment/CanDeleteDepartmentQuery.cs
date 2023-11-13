using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Departments.Queries.CanDeleteDepartment
{
    public class CanDeleteDepartmentQuery : ICanDeleteDepartmentQuery
    {
        private readonly IDepartmentRepository _repository;
        public CanDeleteDepartmentQuery(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(int id)
        {
            bool hasProjects = await _repository.DepartmentHasProjects(id);
            bool hasUsers = await _repository.DepartmentHasUsers(id);
            bool hasBoqSections = await _repository.DepartmentHasBoqSections(id);
            return !hasProjects && !hasUsers && !hasBoqSections;
        }
    }
}
