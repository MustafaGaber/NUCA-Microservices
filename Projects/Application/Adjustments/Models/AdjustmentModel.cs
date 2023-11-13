using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Adjustments.Models
{
    public class AdjustmentModel
    {
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public DateOnly WorksDate { get; set; }
        public int StatementIndex { get; set; }
        public double TotalWorks { get; set; }
        public double TotalSupplies { get; set; }
        public double PreviousTotalWorks { get; set; }
        public double PreviousTotalSupplies { get; set; }
        public double ServiceTax { get; set; }
        public double AdvancedPaymentPercent { get; set; }
        public double AdvancedPaymentValue { get; set; }
        public double CompletionGuaranteeValue { get; set; }
        public double EngineersSyndicateValue { get; set; }
        public double ApplicatorsSyndicateValue { get; set; }
        public double RegularStampDuty { get; set; }
        public double AdditionalStampDuty { get; set; }
        public double CommercialIndustrialTax { get; set; }
        public double ValueAddedTaxPercent { get; set; }
        public double ValueAddedTax { get; set; }
        public double WasteRemovalInsurance { get; set; }
        public double ConractStampDuty { get; set; }
        public double ContractorsFederationValue { get; set; }
        public List<WithholdingModel> Withholdings { get; set; }
        public double Total { get; set; }
        public bool Submitted { get; set; }
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
                ServiceTax = adjustment.ServiceTax,
                AdvancedPaymentPercent = adjustment.AdvancedPaymentPercent,
                AdvancedPaymentValue = adjustment.AdvancedPaymentValue,
                CompletionGuaranteeValue = adjustment.CompletionGuaranteeValue,
                EngineersSyndicateValue = adjustment.EngineersSyndicateValue,
                ApplicatorsSyndicateValue = adjustment.ApplicatorsSyndicateValue,
                RegularStampDuty = adjustment.RegularStampDuty,
                AdditionalStampDuty = adjustment.AdditionalStampDuty,
                CommercialIndustrialTax = adjustment.CommercialIndustrialTax,
                ValueAddedTaxPercent = adjustment.ValueAddedTaxPercent,
                ValueAddedTax = adjustment.ValueAddedTax,
                WasteRemovalInsurance = adjustment.WasteRemovalInsurance,
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
                Total = adjustment.Total,
                Submitted = adjustment.Submitted,
            };
        }
    }

    public class WithholdingModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public WithholdingType Type { get; set; }
        public bool FromStatement { get; set; }
    }
}
