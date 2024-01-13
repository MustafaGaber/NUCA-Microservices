using NUCA.Projects.Application.FinanceAdmin.Banks.Queries;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateBranch
{
    public interface ICreateBranchCommand
    {
        Task<GetBankBranchModel> Execute(long mainBankId, BankBranchModel model);
    }
}
