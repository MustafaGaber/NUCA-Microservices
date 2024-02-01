using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateBoq
{
    public class UpdateBoqCommand : IUpdateBoqCommand
    {
        private readonly IBoqRepository _boqRepository;
        public UpdateBoqCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public async Task<BoqModel> Execute(long boqId, UpdateBoqModel model)
        {
            Boq? boq = await _boqRepository.Get(boqId);
            boq.UpdateBoq(model.PriceChangePercent);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
