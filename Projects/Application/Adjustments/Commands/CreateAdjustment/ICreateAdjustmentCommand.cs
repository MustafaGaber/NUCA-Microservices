namespace NUCA.Projects.Application.Adjustments.Commands.CreateAdjustment
{
    public interface ICreateAdjustmentCommand
    {
        public Task<long> Execute(long projectId, long statementId);
    }
}
