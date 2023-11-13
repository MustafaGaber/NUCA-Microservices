using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Commands
{
    public class ProjectModel
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int TypeId { get; set; }
        public ProjectStatus Status { get; set; }
        public int? AwardTypeId { get; set; }
        public long? CompanyId { get; set; }
        public int? OrderNumber { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double? Price { get; set; }
        public Duration Duration { get; set; }
        public double? AdvancedPaymentPercentage { get; set; }
        public bool? ValueAddedTaxIncluded { get; set; }
        public DateOnly? HandoverDate { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public List<DateOnly> ModifiedEndDates { get; set; }
        public DateOnly? InitialDeliveryDate { get; set; }
        public DateOnly? InitialDeliverySigningDate { get; set; }
        public DateOnly? FinalDeliveryDate { get; set; }
        public int? TotalContractPapers { get; set; }
        public string Notes { get; set; }
    }

}
