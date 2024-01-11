using NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.UpdateCostCenter
{
    public interface IUpdateCostCenterCommand
    {
        Task<GetCostCenterModel> Execute(int id, CostCenterModel model);
    }
}
