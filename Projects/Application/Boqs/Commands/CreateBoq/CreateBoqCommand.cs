using NUCA.Projects.Application.Boqs.Models;
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
        public async Task<BoqModel> Execute(long id, CreateBoqModel model)
        {
            Boq? oldBoq = await _boqRepository.Get(id);
            if (oldBoq == null)
            {
                Boq boq = new Boq(id, model.PriceChangePercent);
                await _boqRepository.Add(boq);
                return new BoqModel(boq);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
