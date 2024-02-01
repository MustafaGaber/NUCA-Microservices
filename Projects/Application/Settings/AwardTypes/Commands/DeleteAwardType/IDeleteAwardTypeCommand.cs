namespace NUCA.Projects.Application.Settings.AwardTypes.Commands.DeleteAwardType
{
    public interface IDeleteAwardTypeCommand
    {
        Task Execute(int id);
    }
}
