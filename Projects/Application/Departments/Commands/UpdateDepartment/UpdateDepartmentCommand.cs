using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Departments;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IUpdateDepartmentCommand
    {
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateDepartmentCommand(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Department> Execute(int id, DepartmentModel model)
        {
           // List<Group> groups = model.GroupsIds.Select(id => _departmentRepository.GetGroup(id)).Where(g => g != null).ToList();
            var department = await _departmentRepository.Get(id);
            if (department == null)
            {
                throw new InvalidOperationException();
            }
            department.Update(model.Name);
            await _departmentRepository.Update(department);
            return department;
        }
    }
}
