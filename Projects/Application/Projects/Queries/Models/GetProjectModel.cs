using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Queries.Models
{
    public class GetProjectModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public ProjectStatus Status { get; set; }
        public int? AwardTypeId { get; set; }
        public string? AwardTypeName { get; set; }
        public int? OrderNumber { get; set; }
        public DateOnly? OrderDate { get; set; }
        public Duration? Duration { get; set; }
        public double? Price { get; set; }
        public long? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double? AdvancedPaymentPercentage { get; set; }
        public double? TotalContractPapers { get; set; }
        public bool? ValueAddedTaxIncluded { get; set; }
        public DateOnly? HandoverDate { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public List<DateOnly> ModifiedEndDates { get; set; }
        public DateOnly? InitialDeliveryDate { get; set; }
        public DateOnly? InitialDeliverySigningDate { get; set; }
        public DateOnly? FinalDeliveryDate { get; set; }
        public string Notes { get; set; }
        public bool HasBoq { get; set; }


        public static GetProjectModel FromProject(Project project, bool hasBoq)
        {
            return new GetProjectModel
            {
                Id = project.Id,
                Name = project.Name,
                DepartmentId = project.Department.Id,
                DepartmentName = project.Department.Name,
                TypeId = project.Type.Id,
                TypeName = project.Type.Name,
                Status = project.Status,
                AwardTypeId = project.AwardType?.Id,
                AwardTypeName = project.AwardType?.Name,
                OrderNumber = project.OrderNumber,
                OrderDate = project.OrderDate,
                Price = project.Price,
                Duration = project.Duration,
                CompanyId = project.Company?.Id,
                CompanyName = project.Company?.Name,
                AdvancedPaymentPercentage = project.AdvancedPaymentPercentage,
                TotalContractPapers = project.TotalContractPapers,
                ValueAddedTaxIncluded = project.ValueAddedTaxIncluded,
                HandoverDate = project.HandoverDate,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ModifiedEndDates = project.ModifiedEndDates.Select(d => d.Value).ToList(),
                InitialDeliveryDate = project.InitialDeliveryDate,
                InitialDeliverySigningDate = project.InitialDeliverySigningDate,
                FinalDeliveryDate = project.FinalDeliveryDate,
                Notes = project.Notes,
                HasBoq = hasBoq,
            };
        }
    }

}
