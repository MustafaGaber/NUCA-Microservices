namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Queries.GetMainBank
{
    public interface IGetMainBankQuery
    {
        Task<GetMainBankModel?> Execute(int id);
    }
}
