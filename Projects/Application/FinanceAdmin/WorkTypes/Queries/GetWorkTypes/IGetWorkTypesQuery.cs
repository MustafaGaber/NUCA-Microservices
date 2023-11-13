namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Queries.GetWorkTypes
{
    public interface IGetWorkTypesQuery
    {
        Task<List<GetWorkTypeModel>> Execute();
    }
}
