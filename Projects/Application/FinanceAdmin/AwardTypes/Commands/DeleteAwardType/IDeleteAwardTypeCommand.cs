namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Commands.DeleteAwardType
{
    public interface IDeleteAwardTypeCommand
    {
        Task Execute(int id);
    }
}
