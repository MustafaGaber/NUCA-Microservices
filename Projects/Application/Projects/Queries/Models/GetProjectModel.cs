using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Queries.Models
{
    public class GetProjectModel
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public int DepartmentId { get; init; }
        public string DepartmentName { get; init; }
        public int TypeId { get; init; }
        public string TypeName { get; init; }
        public ProjectStatus Status { get; init; }
        public int? AwardTypeId { get; init; }
        public string? AwardTypeName { get; init; }
        public int? OrderNumber { get; init; }
        public DateOnly? OrderDate { get; init; }
        public Duration? Duration { get; init; }
        public double? Price { get; init; }
        public long? CompanyId { get; init; }
        public string CompanyName { get; init; }
        public double? AdvancedPaymentPercentage { get; init; }
        public double? TotalContractPapers { get; init; }
        public bool? ValueAddedTaxIncluded { get; init; }
        public DateOnly? HandoverDate { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? EndDate { get; init; }
        public List<DateOnly> ModifiedEndDates { get; init; }
        public DateOnly? InitialDeliveryDate { get; init; }
        public DateOnly? InitialDeliverySigningDate { get; init; }
        public DateOnly? FinalDeliveryDate { get; init; }
        public string Notes { get; init; }
        public bool HasBoq { get; init; }


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
