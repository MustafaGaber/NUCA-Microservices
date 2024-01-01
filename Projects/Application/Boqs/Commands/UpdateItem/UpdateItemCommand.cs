using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateItem
{
    public class UpdateItemCommand : IUpdateItemCommand
    {
        private readonly IBoqRepository _boqRepository;
        public UpdateItemCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long boqId, long tableId, long sectionId, long itemId, UpdateItemModel item)
        {
            Boq? boq = await _boqRepository.Get(boqId);
            if (boq == null)
            {
                throw new InvalidOperationException();
            }
            boq.UpdateItem(tableId, sectionId, itemId, item.Index, item.Content, item.Unit, item.Quantity, item.UnitPrice);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
