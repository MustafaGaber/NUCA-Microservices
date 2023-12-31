using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Ledgers.Commands.CreateLedger;
using NUCA.Projects.Application.Ledgers.Commands.DeleteLedger;
using NUCA.Projects.Application.Ledgers.Commands.UpdateLedger;
using NUCA.Projects.Application.Ledgers.Commands;
using NUCA.Projects.Application.Ledgers.Queries.CanDeleteLedger;
using NUCA.Projects.Application.Ledgers.Queries.GetLedger;
using NUCA.Projects.Application.Ledgers.Queries.GetLedgers;
using Microsoft.AspNetCore.Authorization;

namespace NUCA.Projects.Api.Controllers.Ledgers
{
    [Authorize("FinanceUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class LedgersController : BaseController
    {
        private readonly IGetLedgersQuery _listQuery;
        private readonly IGetLedgerQuery _detailQuery;
        private readonly ICanDeleteLedgerQuery _canDeleteQuery;
        private readonly ICreateLedgerCommand _createCommand;
        private readonly IUpdateLedgerCommand _updateCommand;
        private readonly IDeleteLedgerCommand _deleteCommand;

        public LedgersController(IGetLedgersQuery listQuery, IGetLedgerQuery detailQuery, ICanDeleteLedgerQuery canDeleteQuery, ICreateLedgerCommand createCommand, IUpdateLedgerCommand updateCommand, IDeleteLedgerCommand deleteCommand)
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
            var workTypes = await _listQuery.Execute();
            return Ok(workTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var workType = await _detailQuery.Execute(id);
            return Ok(workType);
        }

        [HttpGet("canDelete/{id}")]
        public async Task<IActionResult> CanDelete(int id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LedgerModel Ledger)
        {
            var result = await _createCommand.Execute(Ledger);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LedgerModel Ledger)
        {
            await _updateCommand.Execute(id, Ledger);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }
    }
}