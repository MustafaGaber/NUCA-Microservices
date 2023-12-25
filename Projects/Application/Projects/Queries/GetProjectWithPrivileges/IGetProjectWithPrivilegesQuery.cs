
namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithPrivileges
{
    public interface IGetProjectWithPrivilegesQuery
    {
        Task<ProjectWithPrivilegesModel> Execute(long id);

    }
}
