namespace NUCA.Projects.Application.Settings.Classifications.Commands.DeleteClassification
{
    public interface IDeleteClassificationCommand
    {
        Task Execute(long id);

    }
}
