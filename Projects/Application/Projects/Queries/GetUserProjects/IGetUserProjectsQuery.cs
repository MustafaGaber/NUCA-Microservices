using NUCA.Projects.Application.Projects.Queries.GetUserProjects;
using NUCA.Projects.Shared.Constants;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public interface IGetUserProjectsQuery
    {
        Task<List<UserProject>> Execute(ClaimsPrincipal user);
    }
}
