using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Models
{
    public class GetAdjustmentModel
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

        public static GetAdjustmentModel Create(Adjustment adjustment, bool isFirst)
        {
            return new GetAdjustmentModel
            {
                ProjectName = adjustment.Project.Name,
                CompanyName = adjustment.Project.Company!.Name,
                WorksDate = adjustment.WorksDate,
                StatementIndex = adjustment.StatementIndex,
                TotalWorks = adjustment.TotalWorks,
                TotalSupplies = adjustment.TotalSupplies,
                PreviousTotalWorks = adjustment.PreviousTotalWorks,
                PreviousTotalSupplies = adjustment.PreviousTotalSupplies,
                CurrentWorks = adjustment.CurrentWorks,
                CurrentSupplies = adjustment.CurrentSupplies,
                CurrentWorksAndSupplies = adjustment.CurrentWorksAndSupplies,
                ServiceTax = adjustment.ServiceTax,
                SupervisionCommission = adjustment.SupervisionCommission,
                AdvancePaymentPercent = adjustment.AdvancePaymentPercent,
                AdvancePaymentValue = adjustment.AdvancePaymentValue,
                CompletionGuaranteeValue = adjustment.CompletionGuaranteeValue,
                EngineersSyndicateValue = adjustment.EngineersSyndicateValue,
                ApplicatorsSyndicateValue = adjustment.ApplicatorsSyndicateValue,
                RegularStampTax = adjustment.RegularStampTax,
                AdditionalStampTax = adjustment.AdditionalStampTax,
                ResourceDevelopmentTax = adjustment.ResourceDevelopmentTax,
                CommercialIndustrialTax = adjustment.CommercialIndustrialTax,
                SelfEmploymentTax = adjustment.SelfEmploymentTax,
                ValueAddedTaxPercent = adjustment.ValueAddedTaxPercent,
                ValueAddedTax = adjustment.ValueAddedTax,
                WasteRemovalInsurance = adjustment.WasteRemovalInsurance,
                TahyaMisrFundValue = adjustment.TahyaMisrFundValue,
                ConractStampTax = adjustment.ConractStampTax,
                ContractorsFederationValue = adjustment.ContractorsFederationValue,
                Withholdings = adjustment.Withholdings.Select(w => new GetWithholdingModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Value = w.Value,
                    Type = w.Type,
                    FromStatement = w.FromStatement
                }).ToList(),
                TotalDue = adjustment.TotalDue,
                TotalWithholdings = adjustment.TotalWithholdings,
                Total = adjustment.Total,
                Submitted = adjustment.Submitted,
                IsFirst = isFirst,
            };
        }
    }
}
