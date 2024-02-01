using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IDeleteDepartmentCommand
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DeleteDepartmentCommand(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task Execute(string id)
        {
            /*bool hasProjects = await _departmentRepository.DepartmentHasProjects(id);
            bool hasUsers = await _departmentRepository.DepartmentHasUsers(id);
            bool hasBoqSections = await _departmentRepository.DepartmentHasBoqSections(id);
            if (!hasProjects && !hasUsers && !hasBoqSections)
            {
                await _departmentRepository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("Department has projects or users");
            }*/
        }
    }
}
