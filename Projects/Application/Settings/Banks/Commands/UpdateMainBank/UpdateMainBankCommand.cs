using NUCA.Projects.Application.Settings.Banks.Queries;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Banks.Commands.UpdateMainBank
{
    public class UpdateMainBankCommand : IUpdateMainBankCommand
    {
        private readonly IBankRepository _repository;
        public UpdateMainBankCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetMainBankModel> Execute(long id, MainBankModel model)
        {
            MainBank? mainBank = await _repository.Get(id) ?? throw new InvalidOperationException();
            mainBank.Update(model.Name);
            await _repository.Update(mainBank);
            return new GetMainBankModel { Id = mainBank.Id, Name = mainBank.Name};
        }
    }
}
