using NUCA.Projects.Application.Settings.Banks.Queries;

namespace NUCA.Projects.Application.Settings.Banks.Commands.UpdateBranch
{
    public interface IUpdateBranchCommand
    {
        Task<GetBankBranchModel> Execute(long id, BankBranchModel model);
    }
}
