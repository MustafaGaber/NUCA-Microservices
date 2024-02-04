namespace NUCA.Projects.Application.Settlements.Commands.CreateSettlement
{
    public interface ICreateSettlementCommand
    {
        public Task Execute(long projectId, long statementId, CreateSettlementModel? model);
    }
}
