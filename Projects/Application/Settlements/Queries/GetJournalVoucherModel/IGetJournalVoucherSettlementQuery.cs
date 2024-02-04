using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Queries.GetJournalVoucherModel
{
    public interface IGetJournalVoucherSettlementQuery
    {
        Task<Settlement?> Execute(long id);

    }
}
