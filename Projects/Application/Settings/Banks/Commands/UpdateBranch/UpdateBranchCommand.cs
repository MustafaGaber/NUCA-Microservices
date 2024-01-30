using NUCA.Projects.Application.Settings.Banks.Queries;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Banks.Commands.UpdateBranch
{
    public class UpdateBranchCommand: IUpdateBranchCommand
    {
        private readonly IBankRepository _repository;
        public UpdateBranchCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBankBranchModel> Execute(long id, BankBranchModel model)
        {
            BankBranch? branch = await _repository.GetBranch(id) ?? throw new InvalidOperationException();
            branch.Update(model.Name);
            await _repository.UpdateBranch(branch);
            return new GetBankBranchModel
            {
                Id = branch.Id,
                Name = branch.Name,
                MainBankId = branch.MainBankId,
            };
        }
    }
}
