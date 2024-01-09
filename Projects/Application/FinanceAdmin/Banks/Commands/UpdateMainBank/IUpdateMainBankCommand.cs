using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Commands.UpdateMainBank
{
    public interface IUpdateMainBankCommand
    {
        Task<MainBank> Execute(int id, MainBankModel model);
    }
}
