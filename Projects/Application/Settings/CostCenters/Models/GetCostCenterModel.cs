namespace NUCA.Projects.Application.Settings.CostCenters.Models
{
    public class GetCostCenterModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required long? ParentId { get; init; }
        public required string? ParentFullPath { get; init; }

    }
}
