using NUCA.Projects.Application.Settings.Classifications.Queries;

namespace NUCA.Projects.Application.Settings.Classifications.Queries.GetClassification
{
    public interface IGetClassificationQuery
    {
        public Task<GetClassificationModel?> Execute(int id);
    }
}
