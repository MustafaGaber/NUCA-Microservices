namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries.CanDeleteCostCenter
{
    public interface ICanDeleteCostCenterQuery
    {
        Task<bool> Execute(int id);
    }
}
