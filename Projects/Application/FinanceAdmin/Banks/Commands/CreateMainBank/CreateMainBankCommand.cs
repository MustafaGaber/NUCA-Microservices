using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Commands.CreateMainBank
{
    public class CreateMainBankCommand : ICreateMainBankCommand
    {
        private readonly IBankRepository _repository;
        public CreateMainBankCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public Task<MainBank> Execute(MainBankModel model)
        {
            return _repository.Add(new MainBank(model.Name, model.ValueAddedTaxPercent));
        }

    }
}
