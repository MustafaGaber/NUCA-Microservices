using NUCA.Projects.Application.Settings.Banks.Queries;

namespace NUCA.Projects.Application.Settings.Banks.Commands.CreateMainBank
{
    public interface ICreateMainBankCommand
    {
        Task<GetMainBankModel> Execute(MainBankModel model);
    }
}
