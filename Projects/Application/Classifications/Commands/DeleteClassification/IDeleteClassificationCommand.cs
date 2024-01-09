namespace NUCA.Projects.Application.Classifications.Commands.DeleteClassification
{
    public interface IDeleteClassificationCommand
    {
        Task Execute(long id);

    }
}
