﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Settings.AwardTypes.Commands;
using NUCA.Projects.Application.Settings.AwardTypes.Commands.CreateAwardType;
using NUCA.Projects.Application.Settings.AwardTypes.Commands.DeleteAwardType;
using NUCA.Projects.Application.Settings.AwardTypes.Commands.UpdateAwardType;
using NUCA.Projects.Application.Settings.AwardTypes.Queries.CanDeleteAwardType;
using NUCA.Projects.Application.Settings.AwardTypes.Queries.GetAwardType;
using NUCA.Projects.Application.Settings.AwardTypes.Queries.GetAwardTypes;

namespace NUCA.Projects.Api.Controllers.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardTypesController : BaseController
    {
        private readonly IGetAwardTypesQuery _listQuery;
        private readonly IGetAwardTypeQuery _detailQuery;
        private readonly ICanDeleteAwardTypeQuery _canDeleteQuery;
        private readonly ICreateAwardTypeCommand _createCommand;
        private readonly IUpdateAwardTypeCommand _updateCommand;
        private readonly IDeleteAwardTypeCommand _deleteCommand;

        public AwardTypesController(IGetAwardTypesQuery listQuery, IGetAwardTypeQuery detailQuery, ICanDeleteAwardTypeQuery canDeleteQuery, ICreateAwardTypeCommand createCommand, IUpdateAwardTypeCommand updateCommand, IDeleteAwardTypeCommand deleteCommand)
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
            var awardTypes = await _listQuery.Execute();
            return Ok(awardTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var awardType = await _detailQuery.Execute(id);
            return Ok(awardType);
        }

        [HttpGet("{id}/CanDelete")]
        public async Task<IActionResult> CanDelete(int id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }

        [Authorize("RevisionUser")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AwardTypeModel AwardType)
        {
            var result = await _createCommand.Execute(AwardType);
            return Ok(result.Id);
        }

        [Authorize("RevisionUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AwardTypeModel AwardType)
        {
            await _updateCommand.Execute(id, AwardType);
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
