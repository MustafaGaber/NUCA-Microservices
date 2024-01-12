using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateBranch
{
    public interface IUpdateBranchCommand
    {
        Task<BankBranch> Execute(long id, BankBranchModel model);
    }
}
