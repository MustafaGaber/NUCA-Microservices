using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Boqs.Commands.CreateItem
{
    public class CreateItemsCommand : ICreateItemsCommand
    {
        private readonly IBoqRepository _boqRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly ICostCenterRepository _costCenterRepository;
        public CreateItemsCommand(IBoqRepository boqRepository, IWorkTypeRepository workTypeRepository, ICostCenterRepository costCenterRepository)
        {
            _boqRepository = boqRepository;
            _workTypeRepository = workTypeRepository;
            _costCenterRepository = costCenterRepository;
        }
        public async Task<BoqModel> Execute(long boqId, long tableId, long sectionId, List<CreateItemModel> items)
        {
            Boq? boq = await _boqRepository.Get(boqId) ?? throw new InvalidOperationException();
            List<WorkType> workTypes = await _workTypeRepository.GetSome(items.Select(i => i.WorkTypeId).Distinct().ToList());
            List<CostCenter> costCenters = await _costCenterRepository.GetSome(items.Select(i => i.CostCenterId).Distinct().ToList());
            items.ForEach(async item =>
            {
                WorkType workType = workTypes.First(w => w.Id == item.WorkTypeId) ?? throw new InvalidOperationException();
                CostCenter costCenter = costCenters.First(c => c.Id == item.CostCenterId) ?? throw new InvalidOperationException();
                boq.AddItem(
                     tableId: tableId,
                    sectionId: sectionId,
                    index: item.Index,
                    content: item.Content,
                    unit: item.Unit,
                    quantity: item.Quantity,
                    unitPrice: item.UnitPrice,
                    workType: workType,
                    isPerformanceRate: item.IsPerformanceRate,
                    sovereign: item.Sovereign,
                    costCenter: costCenter
                 );
            });
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
