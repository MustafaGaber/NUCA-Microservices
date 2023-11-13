using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;


namespace NUCA.Projects.Application.Boqs.Commands.DeleteSection
{
    public class DeleteSectionCommand : IDeleteSectionCommand
    {
        private readonly IBoqRepository _boqRepository;
        public DeleteSectionCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long projectId, long tableId, long sectionId)
        {
            Boq? boq = await _boqRepository.Get(projectId);
            if (boq == null)
            {
                throw new InvalidOperationException();
            }
            boq.DeleteSection(tableId, sectionId);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
