using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Commands
{
    public class ProjectModel
    {
        public string Name { get; init; }
        public string DepartmentId { get; init; }
        public string DepartmentName { get; init; }
        public int TypeId { get; init; }
        public List<long> ClassificationsIds { get; init; }
        public ProjectStatus Status { get; init; }
        public  FundingType FundingType {  get; init; }
        public int? AwardTypeId { get; init; }
        public long? CompanyId { get; init; }
        public int? OrderNumber { get; init; }
        public DateOnly? OrderDate { get; init; }
        public double? Price { get; init; }
        public Duration Duration { get; init; }
        public double? AdvancedPaymentPercentage { get; init; }
        public bool? ValueAddedTaxIncluded { get; init; }
        public DateOnly? HandoverDate { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? EndDate { get; init; }
        public List<DateOnly> ModifiedEndDates { get; init; }
        public DateOnly? InitialDeliveryDate { get; init; }
        public DateOnly? InitialDeliverySigningDate { get; init; }
        public DateOnly? FinalDeliveryDate { get; init; }
        public int? TotalContractPapers { get; init; }
        public string Notes { get; init; }
    }

}
