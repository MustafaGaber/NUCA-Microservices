namespace NUCA.Projects.Application.Boqs.Commands.UpdateSection
{
    public class UpdateSectionModel
    {
        public string SectionName { get; init; }
        public string DepartmentId { get; init; }
        public string DepartmentName { get; init; }
        public long WorkTypeId { get; init; }
        public bool IsPerformanceRate { get; init; }
        public long CostCenterId { get; init; }
        public bool Sovereign { get; init; }

    }
}
