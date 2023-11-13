namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Queries.GetAwardType
{
    public interface IGetAwardTypeQuery
    {
        Task<GetAwardTypeModel?> Execute(int id);
    }
}
