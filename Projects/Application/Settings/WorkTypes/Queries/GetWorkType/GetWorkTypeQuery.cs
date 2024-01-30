using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.WorkTypes.Queries.GetWorkType
{
    public class GetWorkTypeQuery : IGetWorkTypeQuery
    {
        private readonly IWorkTypeRepository _repository;

        public GetWorkTypeQuery(IWorkTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetWorkTypeModel?> Execute(int id)
        {
            var workType = await _repository.Get(id);
            return workType != null ? new GetWorkTypeModel
            {
                Id = workType.Id,
                Name = workType.Name,
                ValueAddedTaxPercent = workType.ValueAddedTaxPercent,
            } : null;
        }

    }
}
