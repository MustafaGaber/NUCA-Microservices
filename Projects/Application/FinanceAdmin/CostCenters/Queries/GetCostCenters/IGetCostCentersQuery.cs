namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries.GetCostCenters
{
    public interface IGetCostCentersQuery
    {
        Task<List<GetCostCenterModel>> Execute();
    }
}
