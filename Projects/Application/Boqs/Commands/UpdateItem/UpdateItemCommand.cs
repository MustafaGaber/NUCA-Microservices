using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateItem
{
    public class UpdateItemCommand : IUpdateItemCommand
    {
        private readonly IBoqRepository _boqRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        public UpdateItemCommand(IBoqRepository boqRepository, IWorkTypeRepository workTypeRepository)
        {
            _boqRepository = boqRepository;
            _workTypeRepository = workTypeRepository;
        }
        public async Task<BoqModel> Execute(long boqId, long tableId, long sectionId, long itemId, UpdateItemModel item)
        {
            Boq? boq = await _boqRepository.Get(boqId) ?? throw new InvalidOperationException();
            WorkType workType = await _workTypeRepository.Get(item.WorkTypeId) ?? throw new InvalidOperationException();
            boq.UpdateItem(
                tableId: tableId,
                sectionId: sectionId,
                itemId: itemId,
                index: item.Index,
                content: item.Content,
                unit: item.Unit,
                quantity: item.Quantity,
                unitPrice: item.UnitPrice,
                workType: workType,
                calculationMethod: item.CalculationMethod,
                sovereign: item.Sovereign
            );
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
