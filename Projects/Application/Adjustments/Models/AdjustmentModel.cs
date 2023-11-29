using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Adjustments.Models
{
    public class AdjustmentModel
    {
        public string ProjectName { get; init; }
        public string CompanyName { get; init; }
        public DateOnly WorksDate { get; init; }
        public int StatementIndex { get; init; }
        public double TotalWorks { get; init; }
        public double TotalSupplies { get; init; }
        public double PreviousTotalWorks { get; init; }
        public double PreviousTotalSupplies { get; init; }
        public double ServiceTax { get; init; }
        public double AdvancedPaymentPercent { get; init; }
        public double AdvancedPaymentValue { get; init; }
        public double CompletionGuaranteeValue { get; init; }
        public double EngineersSyndicateValue { get; init; }
        public double ApplicatorsSyndicateValue { get; init; }
        public double RegularStampDuty { get; init; }
        public double AdditionalStampDuty { get; init; }
        public double CommercialIndustrialTax { get; init; }
        public double ValueAddedTaxPercent { get; init; }
        public double ValueAddedTax { get; init; }
        public double WasteRemovalInsurance { get; init; }
        public double TahyaMisrFundValue { get; init; }
        public double ConractStampDuty { get; init; }
        public double ContractorsFederationValue { get; init; }
        public List<WithholdingModel> Withholdings { get; init; }
        public bool Submitted { get; init; }
        public double CurrentWorks { get; init; }
        public double CurrentSupplies { get; init; }
        public double CurrentWorksAndSupplies { get; init; }
        public double TotalStampDuty { get; init; }
        public double TotalDue { get; init; }
        public double TotalWithholdings { get; init; }
        public double Total { get; init; }

        public static AdjustmentModel FromAdjustmentAndProject(Adjustment adjustment, Project project)
        {
            return new AdjustmentModel()
            {
                ProjectName = project.Name,
                CompanyName = project.Company!.Name,
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
                AdvancedPaymentPercent = adjustment.AdvancedPaymentPercent,
                AdvancedPaymentValue = adjustment.AdvancedPaymentValue,
                CompletionGuaranteeValue = adjustment.CompletionGuaranteeValue,
                EngineersSyndicateValue = adjustment.EngineersSyndicateValue,
                ApplicatorsSyndicateValue = adjustment.ApplicatorsSyndicateValue,
                RegularStampDuty = adjustment.RegularStampDuty,
                AdditionalStampDuty = adjustment.AdditionalStampDuty,
                TotalStampDuty = adjustment.TotalStampDuty,
                CommercialIndustrialTax = adjustment.CommercialIndustrialTax,
                ValueAddedTaxPercent = adjustment.ValueAddedTaxPercent,
                ValueAddedTax = adjustment.ValueAddedTax,
                WasteRemovalInsurance = adjustment.WasteRemovalInsurance,
                TahyaMisrFundValue = adjustment.TahyaMisrFundValue,
                ConractStampDuty = adjustment.ConractStampDuty,
                ContractorsFederationValue = adjustment.ContractorsFederationValue,
                Withholdings = adjustment.Withholdings.Select(w => new WithholdingModel()
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
            };
        }
    }
}
