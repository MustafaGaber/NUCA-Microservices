using NUCA.Projects.Application.Settings.CostCenters.Models;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.CostCenters.Commands.CreateCostCenter
{
    public interface ICreateCostCenterCommand
    {
        Task<GetCostCenterModel> Execute(CostCenterModel model);
    }
}
