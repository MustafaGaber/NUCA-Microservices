using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateMainBank
{
    public class UpdateMainBankCommand : IUpdateMainBankCommand
    {
        private readonly IBankRepository _repository;
        public UpdateMainBankCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<MainBank> Execute(int id, MainBankModel model)
        {
            MainBank? mainBank = await _repository.Get(id) ?? throw new InvalidOperationException();
            mainBank.Update(model.Name);
            await _repository.Update(mainBank);
            return mainBank;
        }
    }
}
