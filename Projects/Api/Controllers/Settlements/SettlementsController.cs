using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Settlements.Commands;
using NUCA.Projects.Application.Settlements.Commands.AddWithholding;
using NUCA.Projects.Application.Settlements.Commands.CreateSettlement;
using NUCA.Projects.Application.Settlements.Commands.DeleteWithholding;
using NUCA.Projects.Application.Settlements.Commands.Submit;
using NUCA.Projects.Application.Settlements.Commands.UpdateSettlement;
using NUCA.Projects.Application.Settlements.Commands.UpdateWithholding;
using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Application.Settlements.Queries.GetSettlement;

namespace NUCA.Projects.Api.Controllers.Settlements
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementsController : BaseController
    {
        private readonly IGetSettlementModelQuery _getSettlementQuery;
        private readonly ICreateSettlementCommand _createSettlementCommand;
        private readonly IUpdateSettlementCommand _updateSettlementCommand;
        private readonly IAddWithholdingCommand _addWithholdingCommand;
        private readonly IUpdateWithholdingCommand _updateWithholdingCommand;
        private readonly IDeleteWithholdingCommand _deleteWithholdingCommand;
        private readonly ISubmitCommand _submitCommand;

        public SettlementsController(IGetSettlementModelQuery getSettlementQuery, ICreateSettlementCommand createSettlementCommand, IAddWithholdingCommand addWithholdingCommand, IUpdateWithholdingCommand updateWithholdingCommand, IDeleteWithholdingCommand deleteWithholdingCommand, ISubmitCommand submitCommand, IUpdateSettlementCommand updateSettlementCommand)
        {
            _getSettlementQuery = getSettlementQuery;
            _createSettlementCommand = createSettlementCommand;
            _addWithholdingCommand = addWithholdingCommand;
            _updateWithholdingCommand = updateWithholdingCommand;
            _deleteWithholdingCommand = deleteWithholdingCommand;
            _submitCommand = submitCommand;
            _updateSettlementCommand = updateSettlementCommand;
        }

        [HttpPost("{projectId}/{statementId}")]
        public async Task<IActionResult> Create(long projectId, long statementId, [FromBody] CreateSettlementModel? model)
        {
            await _createSettlementCommand.Execute(projectId, statementId, model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var settlement = await _getSettlementQuery.Execute(id);
            return Ok(settlement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSettlement(long id, [FromBody] UpdateSettlementModel model)
        {
            GetSettlementModel? result = await _updateSettlementCommand.Execute(id, model);
            return Ok(result);
        }

        [HttpPost("Withholding/{settlementId}")]
        public async Task<IActionResult> AddWithholding(long settlementId, [FromBody] EditWithholdingModel model)
        {
            GetSettlementModel? result = await _addWithholdingCommand.Execute(settlementId, model);
            return Ok(result);
        }

        [HttpPost("Submit/{settlementId}")]
        public async Task<IActionResult> Submit(long settlementId)
        {
            GetSettlementModel? result = await _submitCommand.Execute(settlementId);
            return Ok(result);
        }

        [HttpPut("Withholding/{settlementId}/{withholdingId}")]
        public async Task<IActionResult> UpdateWithholding(long settlementId, long withholdingId, [FromBody] EditWithholdingModel model)
        {
            GetSettlementModel? result = await _updateWithholdingCommand.Execute(settlementId, withholdingId, model);
            return Ok(result);
        }

        [HttpDelete("Withholding/{settlementId}/{withholdingId}")]
        public async Task<IActionResult> DeleteWithholding(long settlementId, long withholdingId)
        {
            GetSettlementModel? result = await _deleteWithholdingCommand.Execute(settlementId, withholdingId);
            return Ok(result);
        }

    }
}
