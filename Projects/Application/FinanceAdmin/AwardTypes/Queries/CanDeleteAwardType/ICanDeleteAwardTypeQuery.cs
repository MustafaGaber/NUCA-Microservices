namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Queries.CanDeleteAwardType
{
    public interface ICanDeleteAwardTypeQuery
    {
        Task<bool> Execute(int id);
    }
}
