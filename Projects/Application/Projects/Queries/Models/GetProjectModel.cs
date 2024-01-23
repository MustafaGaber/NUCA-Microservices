using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Queries.Models
{
    public class GetProjectModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required string DepartmentId { get; init; }
        public required string DepartmentName { get; init; }
        public required long WorkTypeId { get; init; }
        public required string WorkTypeName { get; init; }
        public required long CostCenterId { get; init; }
        public required bool Sovereign { get; init; }
        public required List<long> ClassificationsIds { get; init; }
        public required FundingType FundingType { get; init; }
        public required ProjectStatus Status { get; init; }
        public required long? AwardTypeId { get; init; }
        public required string? AwardTypeName { get; init; }
        public required int? OrderNumber { get; init; }
        public required DateOnly? OrderDate { get; init; }
        public required Duration? Duration { get; init; }
        public required double? Price { get; init; }
        public required long? CompanyId { get; init; }
        public required string CompanyName { get; init; }
        public required double? AdvancePaymentPercentage { get; init; }
        public required int? ContractPapersCount { get; init; }
        public required int? ContractsCount { get; init; }
        public required bool? ValueAddedTaxIncluded { get; init; }
        public required DateOnly? HandoverDate { get; init; }
        public required DateOnly? StartDate { get; init; }
        public required DateOnly? EndDate { get; init; }
        public required List<DateOnly> ModifiedEndDates { get; init; }
        public required DateOnly? InitialDeliveryDate { get; init; }
        public required DateOnly? InitialDeliverySigningDate { get; init; }
        public required DateOnly? FinalDeliveryDate { get; init; }
        public required long? MainBankId { get; init; }
        public required long? BankBranchId { get; init; }
        public required string? BankAccountNumber { get; init; }
        public required long? TaxAuthorityId { get; init; }
        public required string Notes { get; init; }
        public required bool Approved { get; init; }
        public required bool HasBoq { get; init; }
        public static GetProjectModel FromProject(Project project, bool hasBoq)
        {
            return new GetProjectModel
            {
                Id = project.Id,
                Name = project.Name,
                DepartmentId = project.DepartmentId,
                DepartmentName = project.DepartmentName,
                WorkTypeId = project.WorkType.Id,
                WorkTypeName = project.WorkType.Name,
                CostCenterId = project.CostCenter.Id,
                ClassificationsIds = project.Classifications.Select(c => c.Id).ToList(),
                FundingType = project.FundingType,
                Sovereign = project.Sovereign,
                Status = project.Status,
                AwardTypeId = project.AwardType?.Id,
                AwardTypeName = project.AwardType?.Name,
                OrderNumber = project.OrderNumber,
                OrderDate = project.OrderDate,
                Price = project.Price,
                Duration = project.Duration,
                CompanyId = project.Company?.Id,
                CompanyName = project.Company?.Name,
                AdvancePaymentPercentage = project.AdvancePaymentPercentage,
                ContractsCount = project.ContractsCount,
                ContractPapersCount = project.ContractPapersCount,
                ValueAddedTaxIncluded = project.ValueAddedTaxIncluded,
                HandoverDate = project.HandoverDate,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ModifiedEndDates = project.ModifiedEndDates.Select(d => d.Value).ToList(),
                InitialDeliveryDate = project.InitialDeliveryDate,
                InitialDeliverySigningDate = project.InitialDeliverySigningDate,
                FinalDeliveryDate = project.FinalDeliveryDate,
                MainBankId = project.MainBank?.Id,
                BankBranchId = project.BankBranch?.Id,
                BankAccountNumber = project.BankAccountNumber,
                TaxAuthorityId = project.TaxAuthority?.Id,
                Notes = project.Notes,
                HasBoq = hasBoq,
                Approved = project.Approved,
            };
        }
    }

}
