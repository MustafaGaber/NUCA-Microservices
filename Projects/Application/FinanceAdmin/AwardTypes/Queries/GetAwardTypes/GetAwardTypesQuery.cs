using NUCA.Projects.Application.Interfaces.Persistence;


namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Queries.GetAwardTypes
{
    public class GetAwardTypesQuery : IGetAwardTypesQuery
    {

        private readonly IAwardTypeRepository _repository;

        public GetAwardTypesQuery(IAwardTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAwardTypeModel>> Execute()
        {
            return _repository.Select(awardType => new GetAwardTypeModel
            {
                Id = awardType.Id,
                Name = awardType.Name,
                EstimatedPrice = awardType.EstimatedPrice,
            });
        }
    }
}
