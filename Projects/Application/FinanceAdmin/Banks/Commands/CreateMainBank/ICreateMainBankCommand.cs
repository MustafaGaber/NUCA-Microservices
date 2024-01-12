using NUCA.Projects.Application.FinanceAdmin.Banks.Queries;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateMainBank
{
    public interface ICreateMainBankCommand
    {
        Task<GetMainBankModel> Execute(MainBankModel model);
    }
}
