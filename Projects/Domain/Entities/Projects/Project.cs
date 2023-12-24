
using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Shared;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Project : AggregateRoot<long>
    {
        public string Name { get; private set; }
        public string DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
        public WorkType Type { get; private set; }
        public ProjectStatus Status { get; private set; }
        public AwardType? AwardType { get; private set; }
        public Company? Company { get; private set; }
        public int? OrderNumber { get; private set; }
        public DateOnly? OrderDate { get; private set; }
        public double? Price { get; private set; }
        public Duration Duration { get; private set; }
        public bool? ValueAddedTaxIncluded { get; private set; }
        public double? AdvancedPaymentPercentage { get; private set; }
        public DateOnly? HandoverDate { get; private set; }
        public DateOnly? StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }

        private readonly List<Date> _modifiedEndDates = new List<Date>();
        public virtual IReadOnlyList<Date> ModifiedEndDates => _modifiedEndDates.ToList();
        public DateOnly? InitialDeliveryDate { get; private set; }
        public DateOnly? InitialDeliverySigningDate { get; private set; }
        public DateOnly? FinalDeliveryDate { get; private set; }
        public int? TotalContractPapers { get; private set; }
        public string Notes { get; private set; }
        public virtual IReadOnlyList<Statement> Statements { get; private set; }
        public Boq? Boq { get; private set; }

        private readonly List<Privilege> _privileges = new List<Privilege>();
        public virtual IReadOnlyList<Privilege> Privileges => _privileges.ToList();
        protected Project() { }
        public Project(
            string name,
            string departmentId,
            string departmentName,
            WorkType type,
            ProjectStatus status,
            AwardType? awardType,
            Company? company,
            int? orderNumber,
            DateOnly? orderDate,
            double? price,
            Duration duration,
            double? advancedPaymentPercentage,
            bool? valueAddedTaxIncluded,
            DateOnly? handoverDate,
            DateOnly? startDate,
            DateOnly? endDate,
            List<Date> modifiedEndDates,
            DateOnly? initialDeliveryDate,
            DateOnly? initialDeliverySigningDate,
            DateOnly? finalDeliveryDate,
            int? totalContractPapers,
            string notes)
        {
            Update(
                name: name,
                departmentId: departmentId,
                departmentName: departmentName,
                type: type,
                status: status,
                awardType: awardType,
                company: company,
                orderNumber: orderNumber,
                orderDate: orderDate,
                price: price,
                duration: duration,
                advancedPaymentPercentage: advancedPaymentPercentage,
                valueAddedTaxIncluded: valueAddedTaxIncluded,
                handoverDate: handoverDate,
                startDate: startDate,
                endDate: endDate,
                modifiedEndDates: modifiedEndDates,
                initialDeliveryDate: initialDeliveryDate,
                initialDeliverySigningDate: initialDeliverySigningDate,
                finalDeliveryDate: finalDeliveryDate,
                totalContractPapers: totalContractPapers,
                notes: notes
              );
        }

        public void Update(
            string name,
            string departmentId,
            string departmentName,
            WorkType type,
            ProjectStatus status,
            AwardType? awardType,
            Company? company,
            int? orderNumber,
            DateOnly? orderDate,
            double? price,
            Duration duration,
            double? advancedPaymentPercentage,
            bool? valueAddedTaxIncluded,
            DateOnly? handoverDate,
            DateOnly? startDate,
            DateOnly? endDate,
            List<Date> modifiedEndDates,
            DateOnly? initialDeliveryDate,
            DateOnly? initialDeliverySigningDate,
            DateOnly? finalDeliveryDate,
            int? totalContractPapers,
            string notes)
        {
            Name = Guard.Against.NullOrWhiteSpace(name);
            DepartmentId = Guard.Against.NullOrEmpty(departmentId);
            DepartmentName = Guard.Against.NullOrEmpty(departmentName);
            Type = Guard.Against.Null(type, nameof(type));
            Status = Guard.Against.Null(status, nameof(status));
            if (status >= ProjectStatus.Awarded)
            {
                Guard.Against.Null(awardType, nameof(awardType));
                Guard.Against.Null(company, nameof(company));
                Guard.Against.Null(orderNumber, nameof(orderNumber));
                Guard.Against.Null(orderDate, nameof(orderDate));
                Guard.Against.Null(price, nameof(price));
                Guard.Against.NegativeOrZero((double)price, nameof(price));
                Guard.Against.Null(advancedPaymentPercentage, nameof(advancedPaymentPercentage));
                Guard.Against.Null(valueAddedTaxIncluded, nameof(valueAddedTaxIncluded));
                Guard.Against.Null(totalContractPapers);
                Guard.Against.NegativeOrZero((int)totalContractPapers!);
                if (duration.Empty)
                {
                    throw new ArgumentException("Empty duration");
                }
            }
            if (status >= ProjectStatus.Started)
            {
                Guard.Against.Null(handoverDate, nameof(handoverDate));
                Guard.Against.Null(startDate, nameof(startDate));
                Guard.Against.Null(endDate, nameof(endDate));
            }
            if (status >= ProjectStatus.InitiallyDelivered)
            {
                Guard.Against.Null(initialDeliveryDate, nameof(initialDeliveryDate));
                Guard.Against.Null(initialDeliverySigningDate, nameof(initialDeliverySigningDate));
            }
            if (status >= ProjectStatus.FinallyDelivered)
            {
                Guard.Against.Null(finalDeliveryDate, nameof(finalDeliveryDate));
            }
            AwardType = awardType;
            Company = company;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Price = price;
            Duration = duration;
            AdvancedPaymentPercentage = advancedPaymentPercentage == null ? null : Guard.Against.Negative((double)advancedPaymentPercentage, nameof(advancedPaymentPercentage));
            ValueAddedTaxIncluded = valueAddedTaxIncluded;
            HandoverDate = handoverDate;
            StartDate = startDate;
            EndDate = endDate;
            _modifiedEndDates.Clear();
            _modifiedEndDates.AddRange(modifiedEndDates);
            InitialDeliveryDate = initialDeliveryDate;
            InitialDeliverySigningDate = initialDeliverySigningDate;
            FinalDeliveryDate = finalDeliveryDate;
            TotalContractPapers = totalContractPapers;
            Notes = notes;
        }

        public void UpdatePrivileges(List<PrivilegeModel> privileges)
        {
            _privileges.RemoveAll(privilege => !privileges.Any(p => p.Id == privilege.Id));
            privileges.ForEach(p =>
            {
                Privilege? privilege = _privileges.Find(_p => _p.Id == p.Id);
                if (privilege != null)
                {
                    privilege.Update(p.UserId, p.Type, p.DepartmentId);
                }
            });
            _privileges.AddRange(privileges.Where(p => p.Id == 0).Select(p => new Privilege(p.UserId, p.Type, p.DepartmentId )));
        }
    }

}


