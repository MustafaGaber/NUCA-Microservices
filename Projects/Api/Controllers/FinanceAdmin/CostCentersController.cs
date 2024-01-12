using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.CreateCostCenter;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.DeleteCostCenter;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Commands.UpdateCostCenter;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries.CanDeleteCostCenter;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries.GetCostCenter;
using NUCA.Projects.Application.FinanceAdmin.CostCenters.Queries.GetCostCenters;

namespace NUCA.Projects.Api.Controllers.FinanceAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCentersController: BaseController
    {
        private readonly IGetCostCentersQuery _listQuery;
        private readonly IGetCostCenterQuery _detailQuery;
        private readonly ICanDeleteCostCenterQuery _canDeleteQuery;
        private readonly ICreateCostCenterCommand _createCommand;
        private readonly IUpdateCostCenterCommand _updateCommand;
        private readonly IDeleteCostCenterCommand _deleteCommand;

        public CostCentersController(IGetCostCentersQuery listQuery, IGetCostCenterQuery detailQuery, ICanDeleteCostCenterQuery canDeleteQuery, ICreateCostCenterCommand createCommand, IUpdateCostCenterCommand updateCommand, IDeleteCostCenterCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _canDeleteQuery = canDeleteQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var costCenters = await _listQuery.Execute();
            return Ok(costCenters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var costCenter = await _detailQuery.Execute(id);
            return Ok(costCenter);
        }

        [HttpGet("{id}/CanDelete")]
        public async Task<IActionResult> CanDelete(int id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }

        [Authorize("RevisionUser")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CostCenterModel CostCenter)
        {
            GetCostCenterModel costCenter = await _createCommand.Execute(CostCenter);
            return Ok(costCenter);
        }

        [Authorize("RevisionUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CostCenterModel CostCenter)
        {
            GetCostCenterModel costCenter = await _updateCommand.Execute(id, CostCenter);
            return Ok(costCenter);
        }

        [Authorize("RevisionUser")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }
    }
}
