using NUCA.Projects.Application.Projects.Queries.GetUserProjects;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public interface IGetUserProjectsQuery
    {
        Task<List<UserProject>> Execute();
    }
}
