using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Boqs.Commands.CreateTable
{
    public class CreateTableCommand : ICreateTableCommand
    {
        private readonly IBoqRepository _boqRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly ICostCenterRepository _costCenterRepository;
        public CreateTableCommand(IBoqRepository boqRepository, IWorkTypeRepository workTypeRepository, ICostCenterRepository costCenterRepository)
        {
            _boqRepository = boqRepository;
            _workTypeRepository = workTypeRepository;
            _costCenterRepository = costCenterRepository;
        }
        public async Task<BoqModel> Execute(long boqId, CreateTableModel model)
        {
            Boq? boq = await _boqRepository.Get(boqId) ?? throw new InvalidOperationException();
            WorkType? workType = await _workTypeRepository.Get(model.WorkTypeId) ?? throw new InvalidOperationException();
            CostCenter? costCenter = await _costCenterRepository.Get(model.CostCenterId) ?? throw new InvalidOperationException();
            boq.AddTable(
                name:model.TableName,
                count: model.Count,
                priceChangePercent: model.PriceChangePercent,
                type: model.Type,
                 workType: workType,
                isPerformanceRate: model.IsPerformanceRate,
                costCenter: costCenter,
                sovereign: model.Sovereign);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
