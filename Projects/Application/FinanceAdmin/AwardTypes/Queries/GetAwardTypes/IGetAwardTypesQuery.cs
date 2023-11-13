namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Queries.GetAwardTypes
{
    public interface IGetAwardTypesQuery
    {
        Task<List<GetAwardTypeModel>> Execute();
    }
}
