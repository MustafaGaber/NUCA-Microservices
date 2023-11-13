using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;


namespace NUCA.Projects.Application.Boqs.Commands.DeleteItem
{
    public class DeleteItemCommand : IDeleteItemCommand
    {
        private readonly IBoqRepository _boqRepository;
        public DeleteItemCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long projectId, long tableId, long sectionId, long itemId)
        {
            Boq? boq = await _boqRepository.Get(projectId);
            if (boq == null)
            {
                throw new InvalidOperationException();
            }
            boq.DeleteItem(tableId, sectionId, itemId);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
