using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Application.Departments.Commands.DeleteDepartment
{
    public interface IDeleteDepartmentCommand
    {
        Task Execute(int id);
    }
}
