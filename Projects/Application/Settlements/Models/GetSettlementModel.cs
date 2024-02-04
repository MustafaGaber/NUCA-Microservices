using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Models
{
    public class GetSettlementModel
    {
        public required string ProjectName { get; init; }
        public required string CompanyName { get; init; }
        public required DateOnly WorksDate { get; init; }
        public required int StatementIndex { get; init; }
        public required double TotalWorks { get; init; }
        public required double TotalSupplies { get; init; }
        public required double PreviousTotalWorks { get; init; }
        public required double PreviousTotalSupplies { get; init; }
        public required double ServiceTax { get; init; }
        public required double SupervisionCommission { get; init; }
        public required double AdvancePaymentPercent { get; init; }
        public required double AdvancePaymentValue { get; init; }
        public required double CompletionGuaranteeValue { get; init; }
        public required double EngineersSyndicateValue { get; init; }
        public required double ApplicatorsSyndicateValue { get; init; }
        public required double RegularStampTax { get; init; }
        public required double AdditionalStampTax { get; init; }
        public required double ResourceDevelopmentTax { get; init; }
        public required double CommercialIndustrialTax { get; init; }
        public required double SelfEmploymentTax { get; init; }
        public required double ValueAddedTaxPercent { get; init; }
        public required double ValueAddedTax { get; init; }
        public required double WasteRemovalInsurance { get; init; }
        public required double TahyaMisrFundValue { get; init; }
        public required double ConractStampTax { get; init; }
        public required double ContractorsFederationValue { get; init; }
        public required List<GetWithholdingModel> Withholdings { get; init; }
        public required bool Submitted { get; init; }
        public required double CurrentWorks { get; init; }
        public required double CurrentSupplies { get; init; }
        public required double CurrentWorksAndSupplies { get; init; }
        public required double TotalDue { get; init; }
        public required double TotalWithholdings { get; init; }
        public required double Total { get; init; }
        public required bool IsFirst { get; init; }

        public static GetSettlementModel Create(Settlement settlement, bool isFirst)
        {
            return new GetSettlementModel
            {
                ProjectName = settlement.Project.Name,
                CompanyName = settlement.Project.Company!.Name,
                WorksDate = settlement.WorksDate,
                StatementIndex = settlement.StatementIndex,
                TotalWorks = settlement.TotalWorks,
                TotalSupplies = settlement.TotalSupplies,
                PreviousTotalWorks = settlement.PreviousTotalWorks,
                PreviousTotalSupplies = settlement.PreviousTotalSupplies,
                CurrentWorks = settlement.CurrentWorks,
                CurrentSupplies = settlement.CurrentSupplies,
                CurrentWorksAndSupplies = settlement.CurrentWorksAndSupplies,
                ServiceTax = settlement.ServiceTax,
                SupervisionCommission = settlement.SupervisionCommission,
                AdvancePaymentPercent = settlement.AdvancePaymentPercent,
                AdvancePaymentValue = settlement.AdvancePaymentValue,
                CompletionGuaranteeValue = settlement.CompletionGuaranteeValue,
                EngineersSyndicateValue = settlement.EngineersSyndicateValue,
                ApplicatorsSyndicateValue = settlement.ApplicatorsSyndicateValue,
                RegularStampTax = settlement.RegularStampTax,
                AdditionalStampTax = settlement.AdditionalStampTax,
                ResourceDevelopmentTax = settlement.ResourceDevelopmentTax,
                CommercialIndustrialTax = settlement.CommercialIndustrialTax,
                SelfEmploymentTax = settlement.SelfEmploymentTax,
                ValueAddedTaxPercent = settlement.ValueAddedTaxPercent,
                ValueAddedTax = settlement.ValueAddedTax,
                WasteRemovalInsurance = settlement.WasteRemovalInsurance,
                TahyaMisrFundValue = settlement.TahyaMisrFundValue,
                ConractStampTax = settlement.ConractStampTax,
                ContractorsFederationValue = settlement.ContractorsFederationValue,
                Withholdings = settlement.Withholdings.Select(w => new GetWithholdingModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Value = w.Value,
                    Type = w.Type,
                    FromStatement = w.FromStatement
                }).ToList(),
                TotalDue = settlement.TotalDue,
                TotalWithholdings = settlement.TotalWithholdings,
                Total = settlement.NetAmount,
                Submitted = settlement.Submitted,
                IsFirst = isFirst,
            };
        }
    }
}
