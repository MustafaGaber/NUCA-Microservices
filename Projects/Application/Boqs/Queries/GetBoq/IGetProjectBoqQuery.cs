using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Queries.GetBoq
{
    public interface IGetProjectBoqQuery
    {
        Task<BoqModel?> Execute(long projectId);
    }
}
