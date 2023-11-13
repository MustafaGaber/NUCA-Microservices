namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.DeleteWorkType
{
    public interface IDeleteWorkTypeCommand
    {
        Task Execute(int id);
    }
}
