namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBank
{
    public interface IGetMainBankQuery
    {
        Task<GetMainBankModel?> Execute(int id);
    }
}
