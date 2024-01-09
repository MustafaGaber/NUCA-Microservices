namespace NUCA.Projects.Application.Classifications.Queries.CanDeleteClassification
{
    public class CanDeleteClassificationQuery : ICanDeleteClassificationQuery
    {
        public async Task<bool> Execute(long id)
        {
            return true; //TODO
        }
    }
}
