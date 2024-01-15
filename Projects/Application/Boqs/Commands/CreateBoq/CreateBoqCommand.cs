using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Boqs.Commands.CreateBoq
{
    public class CreateBoqCommand : ICreateBoqCommand
    {
        private readonly IBoqRepository _boqRepository;
        public CreateBoqCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<long> Execute(long projectId, CreateBoqModel model)
        {
            Boq? oldBoq = await _boqRepository.GetByProjectId(projectId);
            if (oldBoq == null)
            {
                Boq boq = new Boq(projectId, model.PriceChangePercent);
                await _boqRepository.Add(boq);
                return boq.Id;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
