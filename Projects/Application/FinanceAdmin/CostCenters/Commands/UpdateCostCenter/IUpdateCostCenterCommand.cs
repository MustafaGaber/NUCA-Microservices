using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.UpdateCostCenter
{
    public interface IUpdateCostCenterCommand
    {
        Task<CostCenter> Execute(int id, CostCenterModel model);
    }
}
