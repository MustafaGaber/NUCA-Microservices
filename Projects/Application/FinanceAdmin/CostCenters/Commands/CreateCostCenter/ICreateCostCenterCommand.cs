using NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.CreateCostCenter
{
    public interface ICreateCostCenterCommand
    {
        Task<GetCostCenterModel> Execute(CostCenterModel model);
    }
}
