using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Boqs.Commands.CreateItem
{
    public class CreateItemCommand : ICreateItemCommand
    {
        private readonly IBoqRepository _boqRepository;
        public CreateItemCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long projectId, long tableId, long sectionId, CreateItemModel item)
        {
            Boq? boq = await _boqRepository.GetByProjectId(projectId);
            if (boq == null)
            {
                throw new InvalidOperationException();
            }
            boq.AddItem(tableId, sectionId, item.Index, item.Content, item.Unit, item.Quantity, item.UnitPrice);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
