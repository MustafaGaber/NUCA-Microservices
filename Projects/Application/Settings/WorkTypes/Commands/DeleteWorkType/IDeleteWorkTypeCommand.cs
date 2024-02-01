namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.DeleteWorkType
{
    public interface IDeleteWorkTypeCommand
    {
        Task Execute(int id);
    }
}
