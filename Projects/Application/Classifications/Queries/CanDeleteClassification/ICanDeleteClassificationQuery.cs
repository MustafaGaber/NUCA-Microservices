namespace NUCA.Projects.Application.Classifications.Queries.CanDeleteClassification
{
    public interface ICanDeleteClassificationQuery
    {
        Task<bool> Execute(long id);
    }
}
