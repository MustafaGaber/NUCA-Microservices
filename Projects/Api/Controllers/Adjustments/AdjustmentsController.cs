using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Adjustments.Commands;
using NUCA.Projects.Application.Adjustments.Commands.AddWithholding;
using NUCA.Projects.Application.Adjustments.Commands.CreateAdjustment;
using NUCA.Projects.Application.Adjustments.Commands.DeleteWithholding;
using NUCA.Projects.Application.Adjustments.Commands.Submit;
using NUCA.Projects.Application.Adjustments.Commands.UpdateAdjustment;
using NUCA.Projects.Application.Adjustments.Commands.UpdateWithholding;
using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Adjustments.Queries.GetAdjustment;

namespace NUCA.Projects.Api.Controllers.Adjustments
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjustmentsController : BaseController
    {
        private readonly IGetAdjustmentQuery _getAdjustmentQuery;
        private readonly ICreateAdjustmentCommand _createAdjustmentCommand;
        private readonly IUpdateAdjustmentCommand _updateAdjustmentCommand;
        private readonly IAddWithholdingCommand _addWithholdingCommand;
        private readonly IUpdateWithholdingCommand _updateWithholdingCommand;
        private readonly IDeleteWithholdingCommand _deleteWithholdingCommand;
        private readonly ISubmitCommand _submitCommand;

        public AdjustmentsController(IGetAdjustmentQuery getAdjustmentQuery, ICreateAdjustmentCommand createAdjustmentCommand, IAddWithholdingCommand addWithholdingCommand, IUpdateWithholdingCommand updateWithholdingCommand, IDeleteWithholdingCommand deleteWithholdingCommand, ISubmitCommand submitCommand, IUpdateAdjustmentCommand updateAdjustmentCommand)
        {
            _getAdjustmentQuery = getAdjustmentQuery;
            _createAdjustmentCommand = createAdjustmentCommand;
            _addWithholdingCommand = addWithholdingCommand;
            _updateWithholdingCommand = updateWithholdingCommand;
            _deleteWithholdingCommand = deleteWithholdingCommand;
            _submitCommand = submitCommand;
            _updateAdjustmentCommand = updateAdjustmentCommand;
        }

        [HttpPost("{projectId}/{statementId}")]
        public async Task<IActionResult> Create(long projectId, long statementId, [FromBody] CreateAdjustmentModel? model)
        {
            await _createAdjustmentCommand.Execute(projectId, statementId, model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var adjustment = await _getAdjustmentQuery.Execute(id);
            return Ok(adjustment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdjustment(long id, [FromBody] UpdateAdjustmentModel model)
        {
            GetAdjustmentModel? result = await _updateAdjustmentCommand.Execute(id, model);
            return Ok(result);
        }

        [HttpPost("Withholding/{adjustmentId}")]
        public async Task<IActionResult> AddWithholding(long adjustmentId, [FromBody] EditWithholdingModel model)
        {
            GetAdjustmentModel? result = await _addWithholdingCommand.Execute(adjustmentId, model);
            return Ok(result);
        }

        [HttpPost("Submit/{adjustmentId}")]
        public async Task<IActionResult> Submit(long adjustmentId)
        {
            GetAdjustmentModel? result = await _submitCommand.Execute(adjustmentId);
            return Ok(result);
        }

        [HttpPut("Withholding/{adjustmentId}/{withholdingId}")]
        public async Task<IActionResult> UpdateWithholding(long adjustmentId, long withholdingId, [FromBody] EditWithholdingModel model)
        {
            GetAdjustmentModel? result = await _updateWithholdingCommand.Execute(adjustmentId, withholdingId, model);
            return Ok(result);
        }

        [HttpDelete("Withholding/{adjustmentId}/{withholdingId}")]
        public async Task<IActionResult> DeleteWithholding(long adjustmentId, long withholdingId)
        {
            GetAdjustmentModel? result = await _deleteWithholdingCommand.Execute(adjustmentId, withholdingId);
            return Ok(result);
        }

    }
}
