using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;


namespace NUCA.Projects.Application.Boqs.Commands.DeleteTable
{
    public class DeleteTableCommand : IDeleteTableCommand
    {
        private readonly IBoqRepository _boqRepository;
        public DeleteTableCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long projectId, long tableId)
        {
            Boq? boq = await _boqRepository.Get(projectId);
            if (boq == null)
            {
                throw new InvalidOperationException();
            }
            boq.DeleteTable(tableId);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
