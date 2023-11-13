using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Departments.Commands.CreateDepartment
{
    public interface ICreateDepartmentCommand
    {
        Task<Department> Execute(DepartmentModel model);
    }
}
