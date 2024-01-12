using NUCA.Projects.Application.FinanceAdmin.Banks.Queries;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateMainBank
{
    public interface IUpdateMainBankCommand
    {
        Task<GetMainBankModel> Execute(long id, MainBankModel model);
    }
}
