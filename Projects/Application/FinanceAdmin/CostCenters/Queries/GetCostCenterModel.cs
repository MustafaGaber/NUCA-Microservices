namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries
{
    public class GetCostCenterModel
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public double ValueAddedTaxPercent { get; init; }
    }
}
