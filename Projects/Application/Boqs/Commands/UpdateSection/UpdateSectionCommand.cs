using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateSection
{
    public class UpdateSectionCommand : IUpdateSectionCommand
    {
        private readonly IBoqRepository _boqRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UpdateSectionCommand(IBoqRepository boqRepository, IDepartmentRepository departmentRepository)
        {
            _boqRepository = boqRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task<BoqModel> Execute(long projectId, long tableId, long sectionId, UpdateSectionModel section)
        {
            Boq? boq = await _boqRepository.Get(projectId);
            Department? department = await _departmentRepository.Get(section.DepartmentId);
            if (boq == null || department == null)

            {
                throw new InvalidOperationException();
            }
            boq.UpdateSection(tableId, sectionId, section.SectionName, department);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
