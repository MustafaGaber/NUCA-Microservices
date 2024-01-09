using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.CanDeleteBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetBanks;

namespace NUCA.Projects.Api.Controllers.FinanceAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : BaseController
    {
        private readonly IGetBanksQuery _listQuery;
        private readonly IGetBankQuery _detailQuery;
        private readonly ICanDeleteBankQuery _canDeleteQuery;
        private readonly ICreateBankCommand _createCommand;
        private readonly IUpdateBankCommand _updateCommand;
        private readonly IDeleteBankCommand _deleteCommand;

        public BanksController(IGetBanksQuery listQuery, IGetBankQuery detailQuery, ICanDeleteBankQuery canDeleteQuery, ICreateBankCommand createCommand, IUpdateBankCommand updateCommand, IDeleteBankCommand deleteCommand)
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

        [Authorize("RevisionUser")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BankModel Bank)
        {
            var result = await _createCommand.Execute(Bank);
            return Ok(result.Id);
        }

        [Authorize("RevisionUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BankModel Bank)
        {
            await _updateCommand.Execute(id, Bank);
            return Ok();
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
