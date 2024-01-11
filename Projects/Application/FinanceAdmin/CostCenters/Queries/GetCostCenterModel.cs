namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries
{
    public class GetCostCenterModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required long? ParentId { get; init; }
        public required string? FullParentPath { get; init; }

    }
}
