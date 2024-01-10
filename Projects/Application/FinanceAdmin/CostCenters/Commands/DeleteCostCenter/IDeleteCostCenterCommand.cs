namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.DeleteCostCenter
{
    public interface IDeleteCostCenterCommand
    {
        Task Execute(int id);
    }
}
