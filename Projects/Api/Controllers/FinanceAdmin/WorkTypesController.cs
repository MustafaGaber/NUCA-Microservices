using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands;
using NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.CreateWorkType;
using NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.DeleteWorkType;
using NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.UpdateWorkType;
using NUCA.Projects.Application.FinanceAdmin.WorkTypes.Queries.CanDeleteWorkType;
using NUCA.Projects.Application.FinanceAdmin.WorkTypes.Queries.GetWorkType;
using NUCA.Projects.Application.FinanceAdmin.WorkTypes.Queries.GetWorkTypes;

namespace NUCA.Projects.Api.Controllers.FinanceAdmin
{
    [Authorize("RevisionUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypesController : BaseController
    {
        private readonly IGetWorkTypesQuery _listQuery;
        private readonly IGetWorkTypeQuery _detailQuery;
        private readonly ICanDeleteWorkTypeQuery _canDeleteQuery;
        private readonly ICreateWorkTypeCommand _createCommand;
        private readonly IUpdateWorkTypeCommand _updateCommand;
        private readonly IDeleteWorkTypeCommand _deleteCommand;

        public WorkTypesController(IGetWorkTypesQuery listQuery, IGetWorkTypeQuery detailQuery, ICanDeleteWorkTypeQuery canDeleteQuery, ICreateWorkTypeCommand createCommand, IUpdateWorkTypeCommand updateCommand, IDeleteWorkTypeCommand deleteCommand)
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
        public async Task<IActionResult> Create([FromBody] WorkTypeModel WorkType)
        {
            var result = await _createCommand.Execute(WorkType);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] WorkTypeModel WorkType)
        {
            await _updateCommand.Execute(id, WorkType);
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
