namespace NUCA.Projects.Application.Settings.Banks.Queries.GetMainBanks
{
    public interface IGetMainBanksQuery
    {
        Task<List<GetMainBankModel>> Execute();
    }
}
