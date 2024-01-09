namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Queries.GetMainBanks
{
    public interface IGetMainBanksQuery
    {
        Task<List<GetMainBankModel>> Execute();
    }
}
