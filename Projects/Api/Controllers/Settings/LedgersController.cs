using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Settings.Ledgers.Commands.CreateLedger;
using NUCA.Projects.Application.Settings.Ledgers.Commands.DeleteLedger;
using NUCA.Projects.Application.Settings.Ledgers.Commands.UpdateLedger;
using NUCA.Projects.Application.Settings.Ledgers.Models;
using NUCA.Projects.Application.Settings.Ledgers.Queries.CanDeleteLedger;
using NUCA.Projects.Application.Settings.Ledgers.Queries.GetLedger;
using NUCA.Projects.Application.Settings.Ledgers.Queries.GetLedgers;

namespace NUCA.Projects.Api.Controllers.Settings
{
    // [Authorize("FinanceUser")]
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
            var ledgers = await _listQuery.Execute();
            return Ok(ledgers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ledger = await _detailQuery.Execute(id);
            return Ok(ledger);
        }

        [HttpGet("{id}/CanDelete")]
        public async Task<IActionResult> CanDelete(int id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LedgerModel Ledger)
        {
            var result = await _createCommand.Execute(Ledger);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LedgerModel Ledger)
        {
            var ledger = await _updateCommand.Execute(id, Ledger);
            return Ok(ledger);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }
    }
}