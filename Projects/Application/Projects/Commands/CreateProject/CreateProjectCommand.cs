using NUCA.Projects.Application.Interfaces.Persistence;
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
        public CreateProjectCommand(IProjectRepository projectRepository, ICompanyRepository companyRepository, IDepartmentRepository departmentRepository, IWorkTypeRepository workTypeRepository, IAwardTypeRepository awardTypeRepository)
        {
            _projectRepository = projectRepository;
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _workTypeRepository = workTypeRepository;
            _awardTypeRepository = awardTypeRepository;
        }
        public async Task<Project> Execute(ProjectModel model)
        {
            /* Department? department = await _departmentRepository.Get(model.DepartmentId);
            if (department == null)
            {
                throw new InvalidOperationException();
            }*/
            WorkType? type = await _workTypeRepository.Get(model.TypeId) ?? throw new InvalidOperationException();
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
            var project = await _projectRepository.Add(new Project
            (
                name: model.Name,
                departmentId: model.DepartmentId,
                departmentName: model.DepartmentName,
                type: type,
                status: model.Status,
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
                totalContractPapers: model.TotalContractPapers,
                notes: model.Notes
            ));
            return project;
        }
    }
}
