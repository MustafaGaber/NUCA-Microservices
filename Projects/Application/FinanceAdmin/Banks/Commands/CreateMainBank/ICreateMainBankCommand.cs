using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Commands.CreateMainBank
{
    public interface ICreateMainBankCommand
    {
        Task<MainBank> Execute(MainBankModel model);
    }
}
