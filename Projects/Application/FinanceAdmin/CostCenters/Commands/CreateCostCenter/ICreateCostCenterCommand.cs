using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.CreateCostCenter
{
    public interface ICreateCostCenterCommand
    {
        Task<CostCenter> Execute(CostCenterModel model);
    }
}
