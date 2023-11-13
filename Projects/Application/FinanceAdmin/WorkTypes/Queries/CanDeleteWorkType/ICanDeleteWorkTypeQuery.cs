namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Queries.CanDeleteWorkType
{
    public interface ICanDeleteWorkTypeQuery
    {
        Task<bool> Execute(int id);
    }
}
