using NUCA.Projects.Application.Interfaces.Persistence;


namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Queries.GetWorkTypes
{
    public class GetWorkTypesQuery : IGetWorkTypesQuery
    {

        private readonly IWorkTypeRepository _repository;

        public GetWorkTypesQuery(IWorkTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetWorkTypeModel>> Execute()
        {
            return _repository.Select(workType => new GetWorkTypeModel
            {
                Id = workType.Id,
                Name = workType.Name,
                ValueAddedTaxPercent = workType.ValueAddedTaxPercent,
            });
        }
    }
}
