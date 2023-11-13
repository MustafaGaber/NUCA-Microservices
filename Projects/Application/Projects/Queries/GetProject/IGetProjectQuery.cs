using NUCA.Projects.Application.Projects.Queries.Models;

namespace NUCA.Projects.Application.Projects.Queries.GetProject
{
    public interface IGetProjectQuery
    {
        Task<GetProjectModel> Execute(long Id);
    }
}
