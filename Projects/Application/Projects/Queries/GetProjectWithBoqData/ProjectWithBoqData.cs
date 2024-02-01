namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithBoqData
{
    public class ProjectWithBoqData
    {
        public required string Name { get; init; }
        public required string DepartmentId { get; init; }
        public required string DepartmentName { get; init; }
        public required long WorkTypeId { get; init; }
        public required long CostCenterId { get; init; }
        public required bool Sovereign { get; init; }

    }
}
