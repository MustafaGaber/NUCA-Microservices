using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries.GetCostCenter
{
    public class GetCostCenterQuery : IGetCostCenterQuery
    {
        private readonly ICostCenterRepository _repository;

        public GetCostCenterQuery(ICostCenterRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCostCenterModel?> Execute(int id)
        {
            var costCenter = await _repository.Get(id);
            return costCenter != null ? new GetCostCenterModel
            {
                Id = costCenter.Id,
                Name = costCenter.Name,
                ParentId = costCenter.ParentId,
                FullParentPath = costCenter.ParentFullPath
            } : null;
        }

    }
}
