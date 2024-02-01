namespace NUCA.Projects.Application.Settings.AwardTypes.Queries.GetAwardTypes
{
    public interface IGetAwardTypesQuery
    {
        Task<List<GetAwardTypeModel>> Execute();
    }
}
