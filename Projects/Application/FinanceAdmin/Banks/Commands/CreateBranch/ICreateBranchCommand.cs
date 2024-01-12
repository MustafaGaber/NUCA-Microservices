using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateBranch
{
    public interface ICreateBranchCommand
    {
        Task<BankBranch> Execute(BankBranchModel model);
    }
}
