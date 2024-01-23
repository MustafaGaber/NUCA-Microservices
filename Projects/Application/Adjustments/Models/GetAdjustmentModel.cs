namespace NUCA.Projects.Application.Adjustments.Models
{
    public class GetAdjustmentModel
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
        public double AdvancePaymentPercent { get; init; }
        public double AdvancePaymentValue { get; init; }
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
        public List<GetWithholdingModel> Withholdings { get; init; }
        public bool Submitted { get; init; }
        public double CurrentWorks { get; init; }
        public double CurrentSupplies { get; init; }
        public double CurrentWorksAndSupplies { get; init; }
        public double TotalStampDuty { get; init; }
        public double TotalDue { get; init; }
        public double TotalWithholdings { get; init; }
        public double Total { get; init; }
        public bool IsFirst { get; init; }


    }
}
