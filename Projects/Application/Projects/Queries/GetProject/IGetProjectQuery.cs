using NUCA.Projects.Application.Projects.Queries.Models;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Queries.GetProject
{
    public interface IGetProjectQuery
    {
        Task<GetProjectModel> Execute(long Id, ClaimsPrincipal user);
    }
}
