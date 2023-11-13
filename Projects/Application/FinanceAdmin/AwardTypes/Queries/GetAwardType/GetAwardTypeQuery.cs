using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Queries.GetAwardType
{
    public class GetAwardTypeQuery : IGetAwardTypeQuery
    {
        private readonly IAwardTypeRepository _repository;

        public GetAwardTypeQuery(IAwardTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAwardTypeModel?> Execute(int id)
        {
            var awardType = await _repository.Get(id);
            return awardType != null ? new GetAwardTypeModel
            {
                Id = awardType.Id,
                Name = awardType.Name,
                EstimatedPrice = awardType.EstimatedPrice,
            } : null;
        }

    }
}
