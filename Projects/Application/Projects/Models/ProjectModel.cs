﻿using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Models
{
    public class ProjectModel
    {
        public int CityId { get; init; }
        public string Name { get; init; }
        public string DepartmentId { get; init; }
        public string DepartmentName { get; init; }
        public long WorkTypeId { get; init; }
        public long CostCenterId { get; init; }
        public bool Sovereign { get; init; }
        public List<long> ClassificationsIds { get; init; }
        public ProjectStatus Status { get; init; }
        public FundingType FundingType { get; init; }
        public long? AwardTypeId { get; init; }
        public long? CompanyId { get; init; }
        public int? OrderNumber { get; init; }
        public DateOnly? OrderDate { get; init; }
        public double? Price { get; init; }
        public Duration Duration { get; init; }
        public double? AdvancePaymentPercentage { get; init; }
        public bool? ValueAddedTaxIncluded { get; init; }
        public DateOnly? HandoverDate { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? EndDate { get; init; }
        public List<DateOnly> ModifiedEndDates { get; init; }
        public DateOnly? InitialDeliveryDate { get; init; }
        public DateOnly? InitialDeliverySigningDate { get; init; }
        public DateOnly? FinalDeliveryDate { get; init; }
        public int? ContractPapersCount { get; init; }
        public int? ContractsCount { get; init; }
        public long? MainBankId { get; init; }
        public long? BankBranchId { get; init; }
        public string? BankAccountNumber { get; init; }
        public long? TaxAuthorityId { get; init; }
    }

}
