using NUCA.Projects.Application.Settings.Classifications.Queries;
using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.Classifications.Queries.GetClassifications
{
    public class GetClassificationsQuery : IGetClassificationsQuery
    {
        private readonly IClassificationRepository _repository;

        public GetClassificationsQuery(IClassificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetClassificationModel>> Execute()
        {
            var classifications = await _repository.All();
            return classifications.Select(classification => new GetClassificationModel
            {
                Id = classification.Id,
                Name = classification.Name,
            }).ToList();
        }
    }
}
