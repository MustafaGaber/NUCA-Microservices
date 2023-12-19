using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Boqs.Commands.CreateTable
{
    public class CreateTableCommand : ICreateTableCommand
    {
        private readonly IBoqRepository _boqRepository;
        public CreateTableCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long boqId, CreateTableModel table)
        {
            Boq? boq = await _boqRepository.GetByProjectId(boqId);
            if (boq == null)
            {
                throw new InvalidOperationException();
            }
            boq.AddTable(table.TableName, table.Count, table.PriceChangePercent, table.Type);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
