
using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Shared;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Project : AggregateRoot
    {
        public string Name { get; private set; }
        public string DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
        public long WorkTypeId { get; private set; }
        public WorkType WorkType { get; private set; }
        public long CostCenterId { get; private set; }
        public CostCenter CostCenter { get; private set; }
        public bool Sovereign { get; private set; }

        private readonly List<Classification> _classifications = new();
        public virtual IReadOnlyList<Classification> Classifications => _classifications.ToList();
        public ProjectStatus Status { get; private set; }
        public FundingType FundingType { get; private set; }
        public AwardType? AwardType { get; private set; }
        public long? AwardTypeId { get; private set; }
        public Company? Company { get; private set; }
        public long? CompanyId { get; private set; }
        public int? OrderNumber { get; private set; }
        public DateOnly? OrderDate { get; private set; }
        public double? Price { get; private set; }
        public Duration Duration { get; private set; }
        public bool? ValueAddedTaxIncluded { get; private set; }
        public double? AdvancePaymentPercentage { get; private set; }
        public DateOnly? HandoverDate { get; private set; }
        public DateOnly? StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }

        private readonly List<ModifiedEndDate> _modifiedEndDates = new List<ModifiedEndDate>();
        public virtual IReadOnlyList<ModifiedEndDate> ModifiedEndDates => _modifiedEndDates.ToList();
        public DateOnly? InitialDeliveryDate { get; private set; }
        public DateOnly? InitialDeliverySigningDate { get; private set; }
        public DateOnly? FinalDeliveryDate { get; private set; }
        public int? ContractPapersCount { get; private set; }
        public int? ContractsCount { get; private set; }
        public MainBank? MainBank { get; private set; }
        public long? MainBankId { get; private set; }
        public BankBranch? BankBranch { get; private set; }
        public long? BankBranchId { get; private set; }
        public string? BankAccountNumber { get; private set; }
        public TaxAuthority? TaxAuthority { get; private set; }
        public long? TaxAuthorityId { get; private set; }
        public string Notes { get; private set; }
        public bool Approved { get; private set; }
        public string? ApprovedBy { get; private set; }
        public virtual IReadOnlyList<Statement> Statements { get; private set; }
        public virtual IReadOnlyList<AdvancePaymentDeduction> AdvancePaymentDeductions { get; private set; }
        public Boq? Boq { get; private set; }

        private readonly List<Privilege> _privileges = new List<Privilege>();
        public virtual IReadOnlyList<Privilege> Privileges => _privileges.ToList();
        protected Project() { }
        public Project(
            string name,
            string departmentId,
            string departmentName,
            WorkType workType,
            CostCenter costCenter,
            bool sovereign,
            List<Classification> classifications,
            ProjectStatus status,
            FundingType fundingType,
            AwardType? awardType,
            Company? company,
            int? orderNumber,
            DateOnly? orderDate,
            double? price,
            Duration duration,
            double? advancePaymentPercentage,
            bool? valueAddedTaxIncluded,
            DateOnly? handoverDate,
            DateOnly? startDate,
            DateOnly? endDate,
            List<ModifiedEndDate> modifiedEndDates,
            DateOnly? initialDeliveryDate,
            DateOnly? initialDeliverySigningDate,
            DateOnly? finalDeliveryDate,
            int? contractsCount,
            int? contractPapersCount,
            MainBank? mainBank,
            BankBranch? bankBranch,
            string? bankAccountNumber,
            TaxAuthority? taxAuthority,
            string notes)
        {
            Update(
                name: name,
                departmentId: departmentId,
                departmentName: departmentName,
                workType: workType,
                costCenter: costCenter,
                sovereign: sovereign,
                classifications: classifications,
                status: status,
                fundingType: fundingType,
                awardType: awardType,
                company: company,
                orderNumber: orderNumber,
                orderDate: orderDate,
                price: price,
                duration: duration,
                advancePaymentPercentage: advancePaymentPercentage,
                valueAddedTaxIncluded: valueAddedTaxIncluded,
                handoverDate: handoverDate,
                startDate: startDate,
                endDate: endDate,
                modifiedEndDates: modifiedEndDates,
                initialDeliveryDate: initialDeliveryDate,
                initialDeliverySigningDate: initialDeliverySigningDate,
                finalDeliveryDate: finalDeliveryDate,
                contractsCount: contractsCount,
                contractPapersCount: contractPapersCount,
                mainBank: mainBank,
                bankBranch: bankBranch,
                bankAccountNumber: bankAccountNumber,
                taxAuthority: taxAuthority,
                notes: notes
              );
        }

        public void Update(
            string name,
            string departmentId,
            string departmentName,
            WorkType workType,
            CostCenter costCenter,
            bool sovereign,
            List<Classification> classifications,
            ProjectStatus status,
            FundingType fundingType,
            AwardType? awardType,
            Company? company,
            int? orderNumber,
            DateOnly? orderDate,
            double? price,
            Duration duration,
            double? advancePaymentPercentage,
            bool? valueAddedTaxIncluded,
            DateOnly? handoverDate,
            DateOnly? startDate,
            DateOnly? endDate,
            List<ModifiedEndDate> modifiedEndDates,
            DateOnly? initialDeliveryDate,
            DateOnly? initialDeliverySigningDate,
            DateOnly? finalDeliveryDate,
            int? contractsCount,
            int? contractPapersCount,
            MainBank? mainBank,
            BankBranch? bankBranch,
            string? bankAccountNumber,
            TaxAuthority? taxAuthority,
            string notes)
        {
            /*if (Approved)
            {
                throw new InvalidOperationException();
            }*/
            if (!Enum.IsDefined(typeof(ProjectStatus), status))
            {
                throw new ArgumentException();
            }
            if (!Enum.IsDefined(typeof(FundingType), fundingType))
            {
                throw new ArgumentException();
            }
            Name = Guard.Against.NullOrWhiteSpace(name);
            DepartmentId = Guard.Against.NullOrEmpty(departmentId);
            DepartmentName = Guard.Against.NullOrEmpty(departmentName);
            WorkType = Guard.Against.Null(workType);
            WorkTypeId = Guard.Against.NegativeOrZero(workType.Id);
            CostCenter = Guard.Against.Null(costCenter);
            CostCenterId = Guard.Against.NegativeOrZero(costCenter.Id);
            Sovereign = sovereign;
            _classifications.Clear();
            _classifications.AddRange(classifications);
            Status = Guard.Against.Null(status);
            FundingType = fundingType;
            if (status >= ProjectStatus.Awarded)
            {
                Guard.Against.Null(awardType);
                Guard.Against.Null(company);
                Guard.Against.Null(orderNumber);
                Guard.Against.Null(orderDate);
                Guard.Against.Null(price);
                Guard.Against.NegativeOrZero((double)price, nameof(price));
                Guard.Against.Null(advancePaymentPercentage);
                Guard.Against.Null(valueAddedTaxIncluded);
                Guard.Against.Null(contractsCount);
                Guard.Against.NegativeOrZero((int)contractsCount!);
                Guard.Against.Null(contractPapersCount);
                Guard.Against.NegativeOrZero((int)contractPapersCount!);
                if (duration.Empty)
                {
                    throw new ArgumentException("Empty duration");
                }
            }
            if (status >= ProjectStatus.Started)
            {
                Guard.Against.Null(handoverDate);
                Guard.Against.Null(startDate);
                Guard.Against.Null(endDate);
            }
            if (status >= ProjectStatus.InitiallyDelivered)
            {
                Guard.Against.Null(initialDeliveryDate);
                Guard.Against.Null(initialDeliverySigningDate);
            }
            if (status >= ProjectStatus.FinallyDelivered)
            {
                Guard.Against.Null(finalDeliveryDate);
            }
            AwardType = awardType;
            AwardTypeId = awardType?.Id;
            Company = company;
            CompanyId = company?.Id;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Price = price;
            Duration = duration;
            AdvancePaymentPercentage = advancePaymentPercentage == null ? null : Guard.Against.Negative((double)advancePaymentPercentage, nameof(advancePaymentPercentage));
            ValueAddedTaxIncluded = valueAddedTaxIncluded;
            HandoverDate = handoverDate;
            StartDate = startDate;
            EndDate = endDate;
            _modifiedEndDates.Clear();
            _modifiedEndDates.AddRange(modifiedEndDates);
            InitialDeliveryDate = initialDeliveryDate;
            InitialDeliverySigningDate = initialDeliverySigningDate;
            FinalDeliveryDate = finalDeliveryDate;
            ContractsCount = contractsCount;
            ContractPapersCount = contractPapersCount;
            MainBank = mainBank;
            MainBankId = mainBank?.Id;
            BankBranch = bankBranch;
            BankBranchId = bankBranch?.Id;
            BankAccountNumber = bankAccountNumber;
            TaxAuthority = taxAuthority;
            TaxAuthorityId = taxAuthority?.Id;
            Notes = notes;
        }

        public void Approve(string userId)
        {
            Approved = true;
            ApprovedBy = userId;
        }
        /* public void UpdatePrivileges(List<PrivilegeModel> privileges)
         {
             _privileges.RemoveAll(privilege => !privileges.Any(p => p.Id == privilege.Id));
             privileges.ForEach(p =>
             {
                 Privilege? privilege = _privileges.Find(_p => _p.Id == p.Id);
                 if (privilege != null)
                 {
                     privilege.UpdateStatementData(p.UserId, p.WorkType, p.DepartmentId);
                 }
             });
             _privileges.AddRange(privileges.Where(p => p.Id == 0).Select(p => new Privilege(p.UserId, p.WorkType, p.DepartmentId )));
         }*/
    }

}


