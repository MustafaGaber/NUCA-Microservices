namespace NUCA.Projects.Application.Settings.WorkTypes.Queries.GetWorkType
{
    public interface IGetWorkTypeQuery
    {
        Task<GetWorkTypeModel?> Execute(int id);
    }
}
