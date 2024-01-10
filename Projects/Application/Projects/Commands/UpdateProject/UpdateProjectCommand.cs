using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.CostCenters;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.CostCenters;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IUpdateProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly IAwardTypeRepository _awardTypeRepository;
        private readonly IClassificationRepository _classificationRepository;
        private readonly ICostCenterRepository _costCenterRepository;
        public UpdateProjectCommand(IProjectRepository projectRepository, ICompanyRepository companyRepository, IDepartmentRepository departmentRepository, IWorkTypeRepository workTypeRepository, IAwardTypeRepository awardTypeRepository, IClassificationRepository classificationRepository, ICostCenterRepository costCenterRepository)
        {
            _projectRepository = projectRepository;
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _workTypeRepository = workTypeRepository;
            _awardTypeRepository = awardTypeRepository;
            _classificationRepository = classificationRepository;
            _costCenterRepository = costCenterRepository;
        }
        public async Task<Project> Execute(long id, ProjectModel model)
        {
            Project? project = await _projectRepository.Get(id) ?? throw new InvalidOperationException();
            /*Department? department = await _departmentRepository.Get(model.DepartmentId);
            if (department == null)
            {
                throw new InvalidOperationException();
            }*/
            WorkType? type = await _workTypeRepository.Get(model.TypeId) ?? throw new InvalidOperationException();
            CostCenter? costCenter = await _costCenterRepository.Get(model.CostCenterId) ?? throw new InvalidOperationException();
            AwardType? awardType = model.AwardTypeId == null ? null : await _awardTypeRepository.Get((int)model.AwardTypeId);
            if (model.AwardTypeId != null && awardType == null)
            {
                throw new InvalidOperationException();
            }
            Company? company = model.CompanyId == null ? null : await _companyRepository.Get((long)model.CompanyId);
            if (model.CompanyId != null && company == null)
            {
                throw new InvalidOperationException();
            }
            List<Classification> classifications = await _classificationRepository.GetSome(model.ClassificationsIds);
            project.Update(
                name: model.Name,
                departmentId: model.DepartmentId,
                departmentName: model.DepartmentName,
                type: type,
                costCenter: costCenter,
                classifications: classifications,
                status: model.Status,
                fundingType: model.FundingType,
                awardType: awardType,
                company: company,
                orderNumber: model.OrderNumber,
                orderDate: model.OrderDate,
                price: model.Price,
                duration: model.Duration,
                advancedPaymentPercentage: model.AdvancedPaymentPercentage,
                valueAddedTaxIncluded: model.ValueAddedTaxIncluded,
                handoverDate: model.HandoverDate,
                startDate: model.StartDate,
                endDate: model.EndDate,
                modifiedEndDates: model.ModifiedEndDates.Select(d => new Date(d)).ToList(),
                initialDeliveryDate: model.InitialDeliveryDate,
                initialDeliverySigningDate: model.InitialDeliverySigningDate,
                finalDeliveryDate: model.FinalDeliveryDate,
                contractsCount: model.ContractsCount,
                contractPapersCount: model.ContractPapersCount,
                notes: model.Notes
            );
            await _projectRepository.Update(project);
            return project;
        }
    }
}
