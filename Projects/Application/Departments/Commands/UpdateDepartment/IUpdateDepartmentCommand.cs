using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Departments.Commands.UpdateDepartment
{
    public interface IUpdateDepartmentCommand
    {
        Task<Department> Execute(int id, DepartmentModel model);
    }
}
