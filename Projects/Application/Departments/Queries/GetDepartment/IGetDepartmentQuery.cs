
namespace NUCA.Projects.Application.Departments.Queries.GetDepartment
{
    public interface IGetDepartmentQuery
    {
        Task<GetDepartmentModel> Execute(int id);
    }
}
