namespace NUCA.Projects.Application.Classifications.Queries.GetClassifications
{
    public interface IGetClassificationsQuery
    {
        public Task<List<GetClassificationModel>> Execute();

    }
}
