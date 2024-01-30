using NUCA.Projects.Application.Settings.Banks.Queries;

namespace NUCA.Projects.Application.Settings.Banks.Commands.CreateBranch
{
    public interface ICreateBranchCommand
    {
        Task<GetBankBranchModel> Execute(long mainBankId, BankBranchModel model);
    }
}
