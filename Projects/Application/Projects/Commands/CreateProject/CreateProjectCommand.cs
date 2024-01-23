using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Projects;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly IAwardTypeRepository _awardTypeRepository;
        private readonly IClassificationRepository _classificationRepository;
        private readonly ICostCenterRepository _costCenterRepository;
        private readonly IBankRepository _bankRepository;
        private readonly ITaxAuthorityRepository _taxAuthorityRepository;
        public CreateProjectCommand(IProjectRepository projectRepository, ICompanyRepository companyRepository, IDepartmentRepository departmentRepository, IWorkTypeRepository workTypeRepository, IAwardTypeRepository awardTypeRepository, IClassificationRepository classificationRepository, ICostCenterRepository costCenterRepository, IBankRepository bankRepository)
        {
            _projectRepository = projectRepository;
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _workTypeRepository = workTypeRepository;
            _awardTypeRepository = awardTypeRepository;
            _classificationRepository = classificationRepository;
            _costCenterRepository = costCenterRepository;
            _bankRepository = bankRepository;
        }
        public async Task<Project> Execute(ProjectModel model)
        {
            /* Department? department = await _departmentRepository.Get(model.DepartmentId);
            if (department == null)
            {
                throw new InvalidOperationException();
            }*/
            WorkType? type = await _workTypeRepository.Get(model.WorkTypeId) ?? throw new InvalidOperationException();
            CostCenter? costCenter = await _costCenterRepository.Get(model.CostCenterId) ?? throw new InvalidOperationException();

            AwardType? awardType = model.AwardTypeId == null ? null : await _awardTypeRepository.Get((int)model.AwardTypeId);
            if (model.AwardTypeId != null && awardType == null)
            {
                throw new InvalidOperationException();
            }

            MainBank? mainBank = model.MainBankId == null ? null : await _bankRepository.Get((long)model.MainBankId);
            if (model.MainBankId != null && mainBank == null)
            {
                throw new InvalidOperationException();
            }

            BankBranch? bankBranch = model.BankBranchId == null ? null : await _bankRepository.GetBranch((long)model.BankBranchId);
            if (model.BankBranchId != null && bankBranch == null)
            {
                throw new InvalidOperationException();
            }

            TaxAuthority? taxAuthority = model.TaxAuthorityId == null ? null : await _taxAuthorityRepository.Get((long)model.TaxAuthorityId);
            if (model.TaxAuthorityId != null && taxAuthority == null)
            {
                throw new InvalidOperationException();
            }

            Company? company = model.CompanyId == null ? null : await _companyRepository.Get((long)model.CompanyId);
            if (model.CompanyId != null && company == null)
            {
                throw new InvalidOperationException();
            }
            List<Classification> classifications = await _classificationRepository.GetSome(model.ClassificationsIds);
            var project = await _projectRepository.Add(new Project
            (
                name: model.Name,
                departmentId: model.DepartmentId,
                departmentName: model.DepartmentName,
                workType: type,
                costCenter: costCenter,
                sovereign: model.Sovereign,
                classifications: classifications,
                status: model.Status,
                fundingType: model.FundingType,
                awardType: awardType,
                company: company,
                orderNumber: model.OrderNumber,
                orderDate: model.OrderDate,
                price: model.Price,
                duration: model.Duration,
                advancePaymentPercentage: model.AdvancePaymentPercentage,
                valueAddedTaxIncluded: model.ValueAddedTaxIncluded,
                handoverDate: model.HandoverDate,
                startDate: model.StartDate,
                endDate: model.EndDate,
                modifiedEndDates: model.ModifiedEndDates.Select(d => new ModifiedEndDate(d)).ToList(),
                initialDeliveryDate: model.InitialDeliveryDate,
                initialDeliverySigningDate: model.InitialDeliverySigningDate,
                finalDeliveryDate: model.FinalDeliveryDate,
                contractsCount: model.ContractsCount,
                contractPapersCount: model.ContractPapersCount,
                mainBank: mainBank,
                bankBranch: bankBranch,
                bankAccountNumber: model.BankAccountNumber,
                taxAuthority: taxAuthority,
                notes: model.Notes
            ));
            return project;
        }
    }
}
