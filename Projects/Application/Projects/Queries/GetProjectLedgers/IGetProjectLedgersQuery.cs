using NUCA.Projects.Application.Projects.Models;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectLedgers
{
    public interface IGetProjectLedgersQuery
    {
        Task<GetProjectLedgersModel> Execute(long Id, ClaimsPrincipal user);

    }
}
