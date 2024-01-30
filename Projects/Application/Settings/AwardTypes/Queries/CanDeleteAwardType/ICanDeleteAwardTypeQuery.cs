namespace NUCA.Projects.Application.Settings.AwardTypes.Queries.CanDeleteAwardType
{
    public interface ICanDeleteAwardTypeQuery
    {
        Task<bool> Execute(int id);
    }
}
