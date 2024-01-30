using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Settings;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Boqs.Commands.CreateSection
{
    public class CreateSectionCommand : ICreateSectionCommand
    {
        private readonly IBoqRepository _boqRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly ICostCenterRepository _costCenterRepository;
        public CreateSectionCommand(IBoqRepository boqRepository, IDepartmentRepository departmentRepository, IWorkTypeRepository workTypeRepository, ICostCenterRepository costCenterRepository)
        {
            _boqRepository = boqRepository;
            _departmentRepository = departmentRepository;
            _workTypeRepository = workTypeRepository;
            _costCenterRepository = costCenterRepository;
        }
        public async Task<BoqModel> Execute(long boqId, long tableId, CreateSectionModel model)
        {
            Boq? boq = await _boqRepository.Get(boqId) ?? throw new InvalidOperationException();
            WorkType? workType = await _workTypeRepository.Get(model.WorkTypeId) ?? throw new InvalidOperationException();
            CostCenter? costCenter = await _costCenterRepository.Get(model.CostCenterId) ?? throw new InvalidOperationException();
            boq.AddSection(
                tableId: tableId, 
                sectionName: model.SectionName,
                departmentId: model.DepartmentId, 
                departmentName: model.DepartmentName,
                workType: workType,
                isPerformanceRate: model.IsPerformanceRate,
                costCenter: costCenter,
                sovereign: model.Sovereign
                );
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
