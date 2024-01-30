namespace NUCA.Projects.Application.Settings.Classifications.Queries.CanDeleteClassification
{
    public interface ICanDeleteClassificationQuery
    {
        Task<bool> Execute(long id);
    }
}
