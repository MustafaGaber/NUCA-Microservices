
namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithDepartments
{
    public interface IGetProjectWithDepartmentsQuery
    {
        Task<ProjectWithDepartmentsModel> Execute(long id);

    }
}
