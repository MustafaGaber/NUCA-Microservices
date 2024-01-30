namespace NUCA.Projects.Application.Settings.Banks.Queries.GetMainBank
{
    public interface IGetMainBankQuery
    {
        Task<GetMainBankModel?> Execute(int id);
    }
}
