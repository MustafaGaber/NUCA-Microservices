using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Boqs.Commands.CreateSection
{
    public class CreateSectionCommand : ICreateSectionCommand
    {
        private readonly IBoqRepository _boqRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public CreateSectionCommand(IBoqRepository boqRepository, IDepartmentRepository departmentRepository)
        {
            _boqRepository = boqRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task<BoqModel> Execute(long id, long tableId, CreateSectionModel section)
        {
            Boq? boq = await _boqRepository.Get(id);
            Department? department = await _departmentRepository.Get(section.DepartmentId);
            if (boq == null || department == null)
            {
                throw new InvalidOperationException();
            }
            boq.AddSection(tableId, section.SectionName, department);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
