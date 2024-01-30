namespace NUCA.Projects.Application.Settings.WorkTypes.Queries.CanDeleteWorkType
{
    public interface ICanDeleteWorkTypeQuery
    {
        Task<bool> Execute(int id);
    }
}
