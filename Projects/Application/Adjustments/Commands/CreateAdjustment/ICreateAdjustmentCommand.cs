namespace NUCA.Projects.Application.Adjustments.Commands.CreateAdjustment
{
    public interface ICreateAdjustmentCommand
    {
        public Task Execute(long projectId, long statementId, CreateAdjustmentModel? model);
    }
}
