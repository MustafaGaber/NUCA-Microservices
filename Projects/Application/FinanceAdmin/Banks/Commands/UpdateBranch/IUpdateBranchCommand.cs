using NUCA.Projects.Application.FinanceAdmin.Banks.Queries;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateBranch
{
    public interface IUpdateBranchCommand
    {
        Task<GetBankBranchModel> Execute(long id, BankBranchModel model);
    }
}
