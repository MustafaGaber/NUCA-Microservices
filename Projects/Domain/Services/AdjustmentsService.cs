/*using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Domain.Services
{
    public class SettlementsService
    {
        public static Settlement CreateSettlement(
            long projectId,
            long statementId,
            int statementIndex,
            double totalWorks,
            double totalSupplies,
            double previousTotalWorks,
            double previousTotalSupplies,
            double valueAddedTax,
            bool valueAddedTaxIncluded,
            double advancePaymentPercent,
            bool commercialIndustrialTaxFree,
            int totalContractPapers,
            double orderPrice,
            List<SettlementDiscount> discounts,
            List<SettlementOutstandingAmount> outStandingAmounts,
            List<SettlementDueAmount> dueAmounts)
        {
            Guard.Against.NegativeOrZero(projectId);
            Guard.Against.NegativeOrZero(statementIndex);
            Guard.Against.OutOfRange(valueAddedTax, nameof(valueAddedTax), 0, 100);
            Guard.Against.OutOfRange(advancePaymentPercent, nameof(advancePaymentPercent), 0, 100);
            Guard.Against.NegativeOrZero(totalContractPapers);
            Guard.Against.NegativeOrZero(orderPrice);
            double currentWorks = totalWorks - previousTotalWorks;
            double currentSupplies = totalSupplies - previousTotalSupplies;
            double currentWorksAndSupplies = currentWorks + currentSupplies;
            // double vatOnCurrentWorks = valueAddedTaxIncluded ? 0 : currentWorks * valueAddedTax / 100;
            double originalCurrentWorks = valueAddedTaxIncluded ? currentWorks :
                                          currentWorks * 100 / (100 + valueAddedTax);
            double originalCurrentWorksAndSupplies = originalCurrentWorks + currentSupplies;
            //double advancePaymentValue = currentWorks * advancePaymentPercent / 100;
            double completionGuaranteeValue = currentWorks * 5 / 100;
            double engineersSyndicateValue = currentWorks * 0.0045;
            double applicatorsSyndicateValue = currentWorks * 0.0045;
            double regularStampDuty = CalculateRegularStamp(originalCurrentWorksAndSupplies);
            double additionalStampDuty = 3 * regularStampDuty;
            double commercialIndustrialTaxValue = commercialIndustrialTaxFree ? 0 :
                originalCurrentWorksAndSupplies * .01;
            //double vatValue = originalCurrentWorks * valueAddedTax / 100;
            double wasteRemovalInsurance = currentWorksAndSupplies * .0025;
            double conractStampDuty = statementIndex == 1 ? totalContractPapers : 0;
            double contractorsFederationValue = statementIndex == 1 ?
                                        Math.Min(5000, orderPrice * .0005) : 0;
            return new Settlement(
                projectId: projectId,
                statementId: statementId,
                statementIndex: statementIndex,
                totalWorks: totalWorks,
                totalSupplies: totalSupplies,
                previousTotalWorks: previousTotalWorks,
                previousTotalSupplies: previousTotalSupplies,
                valueAddedTax: valueAddedTax,
                valueAddedTaxIncluded: valueAddedTaxIncluded,
                advancePaymentPercent: advancePaymentPercent,
                completionGuaranteeValue: completionGuaranteeValue,
                engineersSyndicateValue: engineersSyndicateValue,
                applicatorsSyndicateValue: applicatorsSyndicateValue,
                regularStampDuty: regularStampDuty,
                additionalStampDuty: additionalStampDuty,
                commercialIndustrialTaxValue: commercialIndustrialTaxValue,
                //vatValue: vatValue,
                wasteRemovalInsurance: wasteRemovalInsurance,
                conractStampDuty: conractStampDuty,
                contractorsFederationValue: contractorsFederationValue,
                discounts: discounts,
                outStandingAmounts: outStandingAmounts,
                dueAmounts: dueAmounts
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
*/