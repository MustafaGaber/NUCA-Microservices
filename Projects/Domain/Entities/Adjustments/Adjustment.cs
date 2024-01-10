using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using System.ComponentModel;

namespace NUCA.Projects.Domain.Entities.Adjustments
{
    public class Adjustment : AggregateRoot
    {
        public long ProjectId { get; private set; }
        public int StatementIndex { get; private set; }
        public DateOnly WorksDate { get; private set; }
        public double TotalWorks { get; private set; }
        public double TotalSupplies { get; private set; }
        public double PreviousTotalWorks { get; private set; }
        public double PreviousTotalSupplies { get; private set; }
        public double ServiceTax { get; private set; }
        public double AdvancedPaymentPercent { get; private set; }
        public double AdvancedPaymentValue { get; private set; }
        public double CompletionGuaranteeValue { get; private set; }
        public double EngineersSyndicateValue { get; private set; }
        public double ApplicatorsSyndicateValue { get; private set; }
        public double RegularStampDuty { get; private set; }
        public double AdditionalStampDuty { get; private set; }
        public double CommercialIndustrialTax { get; private set; }
        public double ValueAddedTaxPercent { get; private set; }
        public double ValueAddedTax { get; private set; }
        public double WasteRemovalInsurance { get; private set; }
        public double TahyaMisrFundValue { get; private set; }
        public double ConractStampDuty { get; private set; }
        public double ContractorsFederationValue { get; private set; }

        private readonly List<AdjustmentWithholding> _withholdings = new List<AdjustmentWithholding>();
        public virtual IReadOnlyList<AdjustmentWithholding> Withholdings => _withholdings.ToList();
        public double Total { get; private set; }
        public bool Submitted { get; private set; }
        public double CurrentWorks => TotalWorks - PreviousTotalWorks;
        public double CurrentSupplies => TotalSupplies - PreviousTotalSupplies;
        public double CurrentWorksAndSupplies => CurrentWorks + CurrentSupplies;
        public double TotalDue => CurrentWorksAndSupplies + ServiceTax;
        public double TotalStampDuty => RegularStampDuty + AdditionalStampDuty;
        public double TotalWithholdings => AdvancedPaymentValue
                        + CompletionGuaranteeValue
                        + EngineersSyndicateValue
                        + ApplicatorsSyndicateValue
                        + TotalStampDuty
                        + CommercialIndustrialTax
                        + ValueAddedTax
                        + WasteRemovalInsurance
                        + TahyaMisrFundValue
                        + ConractStampDuty
                        + ContractorsFederationValue
                        + Withholdings.Sum(withholding => withholding.Value);
        protected Adjustment()
        {
            double total = TotalDue - TotalWithholdings;
            if (Math.Abs(total - Total) > 0.001)
            {
                throw new InvalidOperationException();
            }
        }

        public Adjustment(long statementId, long projectId, int statementIndex, DateOnly worksDate, double totalWorks, double totalSupplies, double previousTotalWorks, double previousTotalSupplies, double serviceTax, double advancedPaymentPercent, double advancedPaymentValue, double completionGuaranteeValue, double engineersSyndicateValue, double applicatorsSyndicateValue, double regularStampDuty, double additionalStampDuty, double commercialIndustrialTax, double valueAddedTaxPercent, double valueAddedTax, double wasteRemovalInsurance, double tahyaMisrFundValue, double conractStampDuty, double contractorsFederationValue, List<AdjustmentWithholding> withholdings)
        {
            Id = Guard.Against.NegativeOrZero(statementId);
            ProjectId = Guard.Against.NegativeOrZero(projectId);
            StatementIndex = Guard.Against.NegativeOrZero(statementIndex);
            WorksDate = Guard.Against.Null(worksDate);
            TotalWorks = totalWorks;
            TotalSupplies = totalSupplies;
            PreviousTotalWorks = previousTotalWorks;
            PreviousTotalSupplies = previousTotalSupplies;
            ServiceTax = Guard.Against.Negative(serviceTax);
            AdvancedPaymentPercent = Guard.Against.OutOfRange(advancedPaymentPercent, nameof(advancedPaymentPercent), 0, 100);
            AdvancedPaymentValue = Guard.Against.Negative(advancedPaymentValue);
            CompletionGuaranteeValue = Guard.Against.Negative(completionGuaranteeValue);
            EngineersSyndicateValue = Guard.Against.Negative(engineersSyndicateValue);
            ApplicatorsSyndicateValue = Guard.Against.Negative(applicatorsSyndicateValue);
            RegularStampDuty = Guard.Against.Negative(regularStampDuty);
            AdditionalStampDuty = Guard.Against.Negative(additionalStampDuty);
            CommercialIndustrialTax = Guard.Against.Negative(commercialIndustrialTax);
            ValueAddedTaxPercent = Guard.Against.OutOfRange(valueAddedTaxPercent, nameof(valueAddedTaxPercent), 0, 100); ;
            ValueAddedTax = Guard.Against.Negative(valueAddedTax);
            WasteRemovalInsurance = Guard.Against.Negative(wasteRemovalInsurance);
            TahyaMisrFundValue = Guard.Against.Negative(tahyaMisrFundValue);
            ConractStampDuty = Guard.Against.Negative(conractStampDuty);
            ContractorsFederationValue = Guard.Against.Negative(contractorsFederationValue);
            Submitted = false;
            _withholdings = withholdings;
            UpdateTotal();
        }

        public void AddWithholding(AdjustmentWithholding withholding)
        {
            if (Submitted)
            {
                throw new InvalidOperationException();
            }
            _withholdings.Add(withholding);
            UpdateTotal();
        }
        public void UpdateWithholding(long withholdingId, AdjustmentWithholding withholding)
        {
            if (Submitted)
            {
                throw new InvalidOperationException();
            }
            AdjustmentWithholding? oldWithholding = _withholdings.Find(d => d.Id == withholdingId);
            if (oldWithholding == null) return;
            if (oldWithholding.FromStatement)
            {
                throw new InvalidOperationException();
            }
            oldWithholding.Update(withholding.Name, withholding.Value, withholding.Type);
            UpdateTotal();
        }

        public void RemoveWithholding(long id)
        {
            if (Submitted)
            {
                throw new InvalidOperationException();
            }
            AdjustmentWithholding? withholding = _withholdings.Find(d => d.Id == id);
            if (withholding == null) return;
            if (withholding.FromStatement)
            {
                throw new InvalidOperationException();
            }
            _withholdings.Remove(withholding);
            UpdateTotal();
        }

        public void Submit()
        {
            Submitted = true;
        }
        private void UpdateTotal()
        {
            Total = TotalDue - TotalWithholdings;
        }

        public static Adjustment Create(
           long statementId,
           long projectId,
           int statementIndex,
           DateOnly worksDate,
           double totalWorks,
           double totalSupplies,
           double previousTotalWorks,
           double previousTotalSupplies,
           double valueAddedTaxPercent,
           bool valueAddedTaxIncluded,
           double advancedPaymentPercent,
           bool commercialIndustrialTaxFree,
           int contractsCount,
           int contractPapersCount,
           double orderPrice,
           double contractPaperPrice,
           List<AdjustmentWithholding> withholdings)
        {
            Guard.Against.NegativeOrZero(projectId);
            Guard.Against.NegativeOrZero(statementIndex);
            Guard.Against.OutOfRange(valueAddedTaxPercent, nameof(valueAddedTaxPercent), 0, 100);
            Guard.Against.OutOfRange(advancedPaymentPercent, nameof(advancedPaymentPercent), 0, 100);
            Guard.Against.NegativeOrZero(contractsCount);
            Guard.Against.NegativeOrZero(contractPapersCount);
            Guard.Against.NegativeOrZero(orderPrice);
            Guard.Against.Null(worksDate);
            double currentWorks = totalWorks - previousTotalWorks;
            double currentSupplies = totalSupplies - previousTotalSupplies;
            double currentWorksAndSupplies = currentWorks + currentSupplies;
            double serviceTax = valueAddedTaxIncluded ? 0 : currentWorks * valueAddedTaxPercent / 100;
            double originalCurrentWorks = valueAddedTaxIncluded ? currentWorks :
                                          currentWorks * 100 / (100 + valueAddedTaxPercent);
            double originalCurrentWorksAndSupplies = originalCurrentWorks + currentSupplies;
            double remainingAdvancedPaymentValue = Math.Max(0, (orderPrice - previousTotalWorks) * advancedPaymentPercent / 100);
            double advancedPaymentValue = Math.Min(Math.Max(0, currentWorks * advancedPaymentPercent / 100),
                                                   remainingAdvancedPaymentValue);
            double completionGuaranteeValue = Math.Max(0, currentWorks * 5 / 100);
            double engineersSyndicateValue = Math.Max(0, currentWorks * 0.0045);
            double applicatorsSyndicateValue = Math.Max(0, currentWorks * 0.0045);
            double regularStampDuty = CalculateRegularStamp(Math.Max(0, originalCurrentWorksAndSupplies));
            double additionalStampDuty = 3 * regularStampDuty;
            double commercialIndustrialTax = commercialIndustrialTaxFree ? 0 :
                Math.Max(0, originalCurrentWorksAndSupplies * .01);
            double valueAddedTax = Math.Max(0, originalCurrentWorks * valueAddedTaxPercent / 100);
            double wasteRemovalInsurance = Math.Max(0, currentWorksAndSupplies * .0025);
            double tahyaMisrFundValue = Math.Max(0, currentWorksAndSupplies * 0.01);
            double conractStampDuty = statementIndex == 1 ? contractsCount * contractPapersCount * contractPaperPrice : 0;
            double contractorsFederationValue = statementIndex == 1 ?
                                        Math.Min(5000, orderPrice * .0005) : 0;

            return new Adjustment(
                statementId: statementId,
                projectId: projectId,
                statementIndex: statementIndex,
                worksDate: worksDate,
                totalWorks: totalWorks,
                totalSupplies: totalSupplies,
                previousTotalWorks: previousTotalWorks,
                previousTotalSupplies: previousTotalSupplies,
                serviceTax: serviceTax,
                advancedPaymentPercent: advancedPaymentPercent,
                advancedPaymentValue: advancedPaymentValue,
                completionGuaranteeValue: completionGuaranteeValue,
                engineersSyndicateValue: engineersSyndicateValue,
                applicatorsSyndicateValue: applicatorsSyndicateValue,
                regularStampDuty: regularStampDuty,
                additionalStampDuty: additionalStampDuty,
                commercialIndustrialTax: commercialIndustrialTax,
                valueAddedTaxPercent: valueAddedTaxPercent,
                valueAddedTax: valueAddedTax,
                wasteRemovalInsurance: wasteRemovalInsurance,
                tahyaMisrFundValue: tahyaMisrFundValue,
                conractStampDuty: conractStampDuty,
                contractorsFederationValue: contractorsFederationValue,
                withholdings: withholdings
           );
        }


        private static double CalculateRegularStamp(double value)
        {
            if (value <= 50) return 0;
            if (value <= 250)
            {
                return (value - 50) * .012;
            }
            if (value <= 500)
            {
                return (value - 50) * .013;
            }
            if (value <= 1000)
            {
                return (value - 50) * .014;
            }
            if (value <= 5000)
            {
                return (value - 50) * .015;
            }
            if (value <= 10000)
            {
                return (value - 50) * .016;
            }
            return 159.2 + (value - 10000) * .006;
        }

    }
}
