﻿using NUCA.Projects.Application.Settings.CostCenters.Models;
using NUCA.Projects.Application.Interfaces.Persistence;


namespace NUCA.Projects.Application.Settings.CostCenters.Queries.GetCostCenters
{
    public class GetCostCentersQuery : IGetCostCentersQuery
    {

        private readonly ICostCenterRepository _repository;

        public GetCostCentersQuery(ICostCenterRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetCostCenterModel>> Execute()
        {
            return _repository.Select(costCenter => new GetCostCenterModel
            {
                Id = costCenter.Id,
                Name = costCenter.Name,
                ParentId = costCenter.ParentId,
                ParentFullPath = costCenter.ParentFullPath
            });
        }
    }
}
