namespace NUCA.Projects.Application.Classifications.Queries.GetClassification
{
    public interface IGetClassificationQuery
    {
        public Task<GetClassificationModel?> Execute(int id);
    }
}
