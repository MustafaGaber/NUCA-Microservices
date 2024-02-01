using NUCA.Projects.Application.Settings.CostCenters.Models;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.CostCenters.Commands.UpdateCostCenter
{
    public interface IUpdateCostCenterCommand
    {
        Task<GetCostCenterModel> Execute(int id, CostCenterModel model);
    }
}
