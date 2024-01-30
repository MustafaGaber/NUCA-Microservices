using NUCA.Projects.Application.Settings.Classifications.Queries;

namespace NUCA.Projects.Application.Settings.Classifications.Queries.GetClassifications
{
    public interface IGetClassificationsQuery
    {
        public Task<List<GetClassificationModel>> Execute();

    }
}
