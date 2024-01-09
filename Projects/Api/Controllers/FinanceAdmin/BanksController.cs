using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.CanDeleteMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBanks;

namespace NUCA.Projects.Api.Controllers.FinanceAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : BaseController
    {
        private readonly IGetMainBanksQuery _listQuery;
        private readonly IGetMainBankQuery _detailQuery;
        private readonly ICanDeleteMainBankQuery _canDeleteQuery;
        private readonly ICreateMainBankCommand _createCommand;
        private readonly IUpdateMainBankCommand _updateCommand;
        private readonly IDeleteMainBankCommand _deleteCommand;

        public BanksController(IGetMainBanksQuery listQuery, IGetMainBankQuery detailQuery, ICanDeleteMainBankQuery canDeleteQuery, ICreateMainBankCommand createCommand, IUpdateMainBankCommand updateCommand, IDeleteMainBankCommand deleteCommand)
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
        public async Task<IActionResult> Create([FromBody] MainBankModel Bank)
        {
            var result = await _createCommand.Execute(Bank);
            return Ok(result.Id);
        }

        [Authorize("RevisionUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MainBankModel Bank)
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
