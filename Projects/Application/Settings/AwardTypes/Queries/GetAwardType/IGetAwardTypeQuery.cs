namespace NUCA.Projects.Application.Settings.AwardTypes.Queries.GetAwardType
{
    public interface IGetAwardTypeQuery
    {
        Task<GetAwardTypeModel?> Execute(int id);
    }
}
