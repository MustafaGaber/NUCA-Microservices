using NUCA.Projects.Application.Settings.CostCenters.Models;

namespace NUCA.Projects.Application.Settings.CostCenters.Queries.GetCostCenter
{
    public interface IGetCostCenterQuery
    {
        Task<GetCostCenterModel?> Execute(int id);
    }
}
