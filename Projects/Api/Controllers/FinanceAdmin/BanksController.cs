using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateBranch;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.CreateMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteBranch;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateBranch;
using NUCA.Projects.Application.FinanceAdmin.Banks.Commands.UpdateMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.CanDeleteBranch;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.CanDeleteMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBank;
using NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBankBranches;
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
        private readonly IGetMainBankBranchesQuery _getMainBankBranchesQuery;
        private readonly ICanDeleteBranchQuery _canDeleteBranchQuery;
        private readonly ICreateMainBankCommand _createCommand;
        private readonly IUpdateMainBankCommand _updateCommand;
        private readonly IDeleteMainBankCommand _deleteCommand;
        private readonly ICreateBranchCommand _createBranchCommand;
        private readonly IUpdateBranchCommand _updateBranchCommand;
        private readonly IDeleteBranchCommand _deleteBranchCommand;
        public BanksController(IGetMainBanksQuery listQuery, IGetMainBankQuery detailQuery, ICanDeleteMainBankQuery canDeleteQuery, ICreateMainBankCommand createCommand, IUpdateMainBankCommand updateCommand, IDeleteMainBankCommand deleteCommand, IGetMainBankBranchesQuery getMainBankBranchesQuery, ICanDeleteBranchQuery canDeleteBranchQuery, ICreateBranchCommand createBranchCommand, IUpdateBranchCommand updateBranchCommand, IDeleteBranchCommand deleteBranchCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _canDeleteQuery = canDeleteQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _getMainBankBranchesQuery = getMainBankBranchesQuery;
            _canDeleteBranchQuery = canDeleteBranchQuery;
            _createBranchCommand = createBranchCommand;
            _updateBranchCommand = updateBranchCommand;
            _deleteBranchCommand = deleteBranchCommand;
        }

        [HttpGet]
        public async Task<IActionResult> GetMainBanks()
        {
            List<GetMainBankModel> mainBanks = await _listQuery.Execute();
            return Ok(mainBanks);
        }

        [HttpGet("{id}/Branches")]
        public async Task<IActionResult> GetBranches(long id)
        {
            List<GetBankBranchModel> branches = await _getMainBankBranchesQuery.Execute(id);
            return Ok(branches);
        }

        [HttpGet("{id}/CanDelete")]
        public async Task<IActionResult> CanDeleteMainBank(long id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }

        [HttpGet("Branches/{id}/CanDelete")]
        public async Task<IActionResult> CanDeleteBranch(long id)
        {
            bool canDelete = await _canDeleteBranchQuery.Execute(id);
            return Ok(canDelete);
        }

        [Authorize("RevisionUser")]
        [HttpPost]
        public async Task<IActionResult> CreateMainBank([FromBody] MainBankModel model)
        {
            GetMainBankModel mainBank = await _createCommand.Execute(model);
            return Ok(mainBank.Id);
        }

        [Authorize("RevisionUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMainBank(long id, [FromBody] MainBankModel model)
        {
            GetMainBankModel mainBank = await _updateCommand.Execute(id, model);
            return Ok(mainBank);
        }

        [Authorize("RevisionUser")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainBank(long id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }

        [Authorize("RevisionUser")]
        [HttpPost("{mainBankId}/Branches")]
        public async Task<IActionResult> CreateBranch(long mainBankId, [FromBody] BankBranchModel model)
        {
            GetBankBranchModel branch = await _createBranchCommand.Execute(mainBankId, model);
            return Ok(branch.Id);
        }

        [Authorize("RevisionUser")]
        [HttpPut("Branches/{branchId}")]
        public async Task<IActionResult> UpdateBranch(long branchId, [FromBody] BankBranchModel model)
        {
            GetBankBranchModel branch = await _updateBranchCommand.Execute(branchId, model);
            return Ok(branch);
        }

        [Authorize("RevisionUser")]
        [HttpDelete("Branches/{id}")]
        public async Task<IActionResult> DeleteBranch(long id)
        {
            await _deleteBranchCommand.Execute(id);
            return Ok();
        }
    }
}
