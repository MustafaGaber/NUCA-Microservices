namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries.GetCostCenter
{
    public interface IGetCostCenterQuery
    {
        Task<GetCostCenterModel?> Execute(int id);
    }
}
