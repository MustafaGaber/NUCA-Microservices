namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBanks
{
    public interface IGetMainBanksQuery
    {
        Task<List<GetMainBankModel>> Execute();
    }
}
