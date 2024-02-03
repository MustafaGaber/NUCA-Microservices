using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Domain.Entities.Adjustments
{
    public class Adjustment : AggregateRoot
    {
        public Project Project { get; private set; }
        public Statement Statement { get; private set; }
        public long ProjectId { get; private set; }
        public int StatementIndex { get; private set; }
        public DateOnly WorksDate { get; private set; }
        public double TotalWorks { get; private set; }
        public double TotalSupplies { get; private set; }
        public double PreviousTotalWorks { get; private set; }
        public double PreviousTotalSupplies { get; private set; }
        public double ServiceTax { get; private set; }
        public double SupervisionCommission { get; private set; }
        public double AdvancePaymentPercent { get; private set; }
        public double AdvancePaymentValue { get; private set; }
        public double CompletionGuaranteeValue { get; private set; }
        public double EngineersSyndicateValue { get; private set; }
        public double ApplicatorsSyndicateValue { get; private set; }
        public double RegularStampTax { get; private set; }
        public double AdditionalStampTax { get; private set; }
        public double ResourceDevelopmentTax { get; private set; }
        public double CommercialIndustrialTax { get; private set; }
        public double SelfEmploymentTax { get; private set; }
        public double ValueAddedTaxPercent { get; private set; }
        public double ValueAddedTax { get; private set; }
        public double WasteRemovalInsurance { get; private set; }
        public double TahyaMisrFundValue { get; private set; }
        public double ConractStampTax { get; private set; }
        public double ContractorsFederationValue { get; private set; }

        private readonly List<AdjustmentWithholding> _withholdings = new();
        public virtual IReadOnlyList<AdjustmentWithholding> Withholdings => _withholdings.ToList();
        public AdvancePaymentDeduction? AdvancePaymentDeduction { get; private set; }
        public double Total { get; private set; }
        public bool Submitted { get; private set; }
        public double CurrentWorks => TotalWorks - PreviousTotalWorks;
        public double CurrentSupplies => TotalSupplies - PreviousTotalSupplies;
        public double CurrentWorksAndSupplies => CurrentWorks + CurrentSupplies;
        public double TotalDue => CurrentWorksAndSupplies + ServiceTax;
        public double TotalWithholdings
        {
            get
            {
                return SupervisionCommission
                        + AdvancePaymentValue
                        + CompletionGuaranteeValue
                        + EngineersSyndicateValue
                        + ApplicatorsSyndicateValue
                        + RegularStampTax
                        + AdditionalStampTax
                        + ResourceDevelopmentTax
                        + CommercialIndustrialTax
                        + SelfEmploymentTax
                        + ValueAddedTax
                        + WasteRemovalInsurance
                        + TahyaMisrFundValue
                        + ConractStampTax
                        + ContractorsFederationValue
                        + Withholdings.Sum(withholding => withholding.Value);
            }
        }

        protected Adjustment()
        {
            double total = TotalDue - TotalWithholdings;
            if (Math.Abs(total - Total) > 0.001)
            {
                throw new InvalidOperationException();
            }
        }

        public Adjustment(
             Statement statement,
             Project project,
             double previousTotalWorks,
             double previousTotalSupplies,
             double totalAdvancePaymentDeductions,
             double contractPaperPrice)
        {
            Statement = Guard.Against.Null(statement);
            Project = Guard.Against.Null(project);
            Id = Guard.Against.NegativeOrZero(statement.Id);
            ProjectId = Guard.Against.NegativeOrZero(project.Id);
            StatementIndex = Guard.Against.NegativeOrZero(statement.Index);
            WorksDate = Guard.Against.Null(statement.WorksDate);
            Submitted = false;
            _withholdings.AddRange(statement.Withholdings.Select(w => new AdjustmentWithholding(w.Name, w.Value, w.Type, true)));
            Update(
                previousTotalWorks: previousTotalWorks,
                previousTotalSupplies: previousTotalSupplies,
                totalAdvancePaymentDeductions: totalAdvancePaymentDeductions,
                contractPaperPrice: contractPaperPrice
            );
        }

        public void Update(double previousTotalWorks, double previousTotalSupplies, double totalAdvancePaymentDeductions, double contractPaperPrice)
        {
            TotalWorks = Statement.TotalWorks;
            TotalSupplies = Statement.TotalSupplies;
            PreviousTotalWorks = previousTotalWorks;
            PreviousTotalSupplies = previousTotalSupplies;
            double currentWorks = TotalWorks - previousTotalWorks;
            double currentSupplies = TotalSupplies - previousTotalSupplies;
            double currentWorksAndSupplies = currentWorks + currentSupplies;
            ValueAddedTaxPercent = Guard.Against.OutOfRange(Project.WorkType.ValueAddedTaxPercent, nameof(Project.WorkType.ValueAddedTaxPercent), 0, 100);
            bool valueAddedTaxIncluded = (bool)Project.ValueAddedTaxIncluded!;
            ServiceTax = valueAddedTaxIncluded ? 0 : currentWorks * ValueAddedTaxPercent / 100;
            AdvancePaymentPercent = Guard.Against.OutOfRange((double)Project.AdvancePaymentPercentage!, nameof(Project.AdvancePaymentPercentage), 0, 100);
            double orderPrice = (double)Project.Price!;
            double remainingAdvancePaymentValue = Math.Max(0, orderPrice * AdvancePaymentPercent / 100 - totalAdvancePaymentDeductions);
            AdvancePaymentValue = Guard.Against.Negative(Math.Min(Math.Max(0, currentWorks * AdvancePaymentPercent / 100), remainingAdvancePaymentValue));
            CompletionGuaranteeValue = currentWorks * 5 / 100;
            EngineersSyndicateValue = currentWorks * 0.0045;
            ApplicatorsSyndicateValue = currentWorks * 0.0045;
            double originalCurrentWorks = valueAddedTaxIncluded ? currentWorks :
                                         currentWorks * 100 / (100 + ValueAddedTaxPercent);
            double originalCurrentWorksAndSupplies = originalCurrentWorks + currentSupplies;
            bool isCooperative = Project.Company!.Type == CompanyType.Cooperative;
            SupervisionCommission = Project.FundingType == FundingType.HousingFund ? originalCurrentWorks * 1.15 / 100 : 0;
            RegularStampTax = isCooperative ? 0 : CalculateRegularStamp(originalCurrentWorksAndSupplies);
            AdditionalStampTax = 3 * RegularStampTax;
            ResourceDevelopmentTax = isCooperative ? 0 : 2; //  2 * papers count ???
            CommercialIndustrialTax = isCooperative || Project.Company!.CommercialIndustrialTaxFree == true ? 0 : originalCurrentWorksAndSupplies * Project.WorkType.CommercialIndustrialTaxPercent / 100;
            SelfEmploymentTax = originalCurrentWorks * Project.WorkType.SelfEmploymentTaxPercent / 100;
            ValueAddedTax = originalCurrentWorks * ValueAddedTaxPercent / 100;
            WasteRemovalInsurance = currentWorksAndSupplies * .0025;
            TahyaMisrFundValue = currentWorksAndSupplies * 0.01;
            int contractsCount = (int)Project.ContractsCount!;
            int contractPapersCount = (int)Project.ContractPapersCount!;
            ConractStampTax = Statement.Index > 1 || isCooperative ? 0 : contractsCount * contractPapersCount * contractPaperPrice;
            ContractorsFederationValue = Statement.Index == 1 ? Math.Min(5000, orderPrice * .0005) : 0;
            if (AdvancePaymentValue > 0)
            {
                AdvancePaymentDeduction = new AdvancePaymentDeduction
                {
                    ProjectId = Project.Id,
                    Amount = AdvancePaymentValue
                };
            }
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
