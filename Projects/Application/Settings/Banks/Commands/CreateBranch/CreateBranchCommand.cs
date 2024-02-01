using NUCA.Projects.Application.Settings.Banks.Queries;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Banks.Commands.CreateBranch
{
    public class CreateBranchCommand : ICreateBranchCommand
    {
        private readonly IBankRepository _repository;
        public CreateBranchCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBankBranchModel> Execute(long mainBankId, BankBranchModel model)
        {
            MainBank mainBank = await _repository.Get(mainBankId) ?? throw new ArgumentNullException();
            var branch = await _repository.AddBranch(new BankBranch(model.Name, mainBank));
            return new GetBankBranchModel { Id = branch.Id, MainBankId = branch.MainBankId, Name = branch.Name };
        }
    }
}
