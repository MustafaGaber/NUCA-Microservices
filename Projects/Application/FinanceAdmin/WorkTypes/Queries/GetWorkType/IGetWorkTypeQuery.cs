namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Queries.GetWorkType
{
    public interface IGetWorkTypeQuery
    {
        Task<GetWorkTypeModel?> Execute(int id);
    }
}
