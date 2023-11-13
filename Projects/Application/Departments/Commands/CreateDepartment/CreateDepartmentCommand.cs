using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Departments;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : ICreateDepartmentCommand
    {
        private readonly IDepartmentRepository _departmentRepository;
        public CreateDepartmentCommand(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public Task<Department> Execute(DepartmentModel model)
        {
           // List<Group> groups = model.GroupsIds.Select(id => _departmentRepository.GetGroup(id)).Where(g => g != null).ToList();
            return _departmentRepository.Add(new Department(model.Name));
        }
    }
}
