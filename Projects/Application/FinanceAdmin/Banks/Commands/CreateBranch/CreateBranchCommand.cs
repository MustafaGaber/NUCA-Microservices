using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateBranch
{
    public class CreateBranchCommand : ICreateBranchCommand
    {
        private readonly IBankRepository _repository;
        public CreateBranchCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<BankBranch> Execute(BankBranchModel model)
        {
            MainBank mainBank = await _repository.Get(model.MainBankId) ?? throw new ArgumentNullException();
            var branch = await _repository.AddBranch(new BankBranch(model.Name, mainBank));
            return branch;
        }
    }
}
