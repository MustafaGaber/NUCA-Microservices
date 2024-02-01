using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Settings.Classifications.Commands;
using NUCA.Projects.Application.Settings.Classifications.Commands.CreateClassification;
using NUCA.Projects.Application.Settings.Classifications.Commands.DeleteClassification;
using NUCA.Projects.Application.Settings.Classifications.Commands.UpdateClassification;
using NUCA.Projects.Application.Settings.Classifications.Queries.CanDeleteClassification;
using NUCA.Projects.Application.Settings.Classifications.Queries.GetClassification;
using NUCA.Projects.Application.Settings.Classifications.Queries.GetClassifications;

namespace NUCA.Projects.Api.Controllers.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationsController : BaseController
    {
        private readonly IGetClassificationsQuery _listQuery;
        private readonly IGetClassificationQuery _detailQuery;
        private readonly ICanDeleteClassificationQuery _canDeleteQuery;
        private readonly ICreateClassificationCommand _createCommand;
        private readonly IUpdateClassificationCommand _updateCommand;
        private readonly IDeleteClassificationCommand _deleteCommand;

        public ClassificationsController(IGetClassificationsQuery listQuery, IGetClassificationQuery detailQuery, ICanDeleteClassificationQuery canDeleteQuery, ICreateClassificationCommand createCommand, IUpdateClassificationCommand updateCommand, IDeleteClassificationCommand deleteCommand)
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

        [HttpGet("{id}/CanDelete")]
        public async Task<IActionResult> CanDelete(int id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClassificationModel Classification)
        {
            var result = await _createCommand.Execute(Classification);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClassificationModel Classification)
        {
            await _updateCommand.Execute(id, Classification);
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
