using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateTable
{
    public class UpdateTableCommand : IUpdateTableCommand
    {
        private readonly IBoqRepository _boqRepository;
        public UpdateTableCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long id, long tableId, UpdateTableModel table)
        {
            Boq? boq = await _boqRepository.GetByProjectId(id);
            if (boq == null)
            {
                throw new InvalidOperationException();
            }
            boq.UpdateTable(tableId, table.TableName, table.Count, table.PriceChangePercent, table.Type);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
