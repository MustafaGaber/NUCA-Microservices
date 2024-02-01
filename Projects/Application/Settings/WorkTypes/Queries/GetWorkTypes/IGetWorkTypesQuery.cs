namespace NUCA.Projects.Application.Settings.WorkTypes.Queries.GetWorkTypes
{
    public interface IGetWorkTypesQuery
    {
        Task<List<GetWorkTypeModel>> Execute();
    }
}
