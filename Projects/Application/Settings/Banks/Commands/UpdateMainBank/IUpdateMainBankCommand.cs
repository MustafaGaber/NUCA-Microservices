using NUCA.Projects.Application.Settings.Banks.Queries;

namespace NUCA.Projects.Application.Settings.Banks.Commands.UpdateMainBank
{
    public interface IUpdateMainBankCommand
    {
        Task<GetMainBankModel> Execute(long id, MainBankModel model);
    }
}
