using NUCA.Projects.Application.Settings.CostCenters.Models;

namespace NUCA.Projects.Application.Settings.CostCenters.Queries.GetCostCenters
{
    public interface IGetCostCentersQuery
    {
        Task<List<GetCostCenterModel>> Execute();
    }
}
