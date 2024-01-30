namespace NUCA.Projects.Application.Settings.CostCenters.Queries.CanDeleteCostCenter
{
    public interface ICanDeleteCostCenterQuery
    {
        Task<bool> Execute(int id);
    }
}
