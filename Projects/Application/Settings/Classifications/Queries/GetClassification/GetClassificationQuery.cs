using NUCA.Projects.Application.Settings.Classifications.Queries;
using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.Classifications.Queries.GetClassification
{
    public class GetClassificationQuery : IGetClassificationQuery
    {
        private readonly IClassificationRepository _repository;

        public GetClassificationQuery(IClassificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetClassificationModel?> Execute(int id)
        {
            var classification = await _repository.Get(id);
            return classification != null ? new GetClassificationModel
            {
                Id = classification.Id,
                Name = classification.Name,
            } : null;
        }
    }
}
