using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Statements.Commands.CreateStatement;
using NUCA.Projects.Application.Statements.Commands.TechnicalOfficeSubmit;
using NUCA.Projects.Application.Statements.Commands.UpdateStatement;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Application.Statements.Queries.GetProjectStatements;
using NUCA.Projects.Application.Statements.Queries.GetStatement;
using NUCA.Projects.Application.Statements.Queries.GetUserStatements;
using NUCA.Projects.Domain.Entities.Statements;
using NUCA.Projects.Shared.Extensions;

namespace NUCA.Projects.Api.Controllers.Statements
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementsController : BaseController
    {
        private readonly IGetStatementQuery _getStatementQuery;
        private readonly IGetCurrentStatementsQuery _getCurrentStatementsQuery;
        private readonly IGetProjectStatementsQuery _getProjectStatementsQuery;
        private readonly ICreateStatementCommand _createCommand;
        private readonly IUpdateStatementCommand _updateStatementCommand;
        private readonly ITechnicalOfficeSubmitCommand _technicalOfficeSubmitCommand;

        public StatementsController(IGetStatementQuery getStatementQuery, IGetCurrentStatementsQuery getCurrentStatementsQuery, IGetProjectStatementsQuery getProjectStatementsQuery, ICreateStatementCommand createCommand, IUpdateStatementCommand updateStatementCommand, ITechnicalOfficeSubmitCommand technicalOfficeSubmitCommand)
        {
            _getStatementQuery = getStatementQuery;
            _getCurrentStatementsQuery = getCurrentStatementsQuery;
            _getProjectStatementsQuery = getProjectStatementsQuery;
            _createCommand = createCommand;
            _updateStatementCommand = updateStatementCommand;
            _technicalOfficeSubmitCommand = technicalOfficeSubmitCommand;
        }

        [HttpGet("ProjectStatements/{projectId}")]
        public async Task<IActionResult> GetProjectStatements(long projectId)
        {
            var statements = await _getProjectStatementsQuery.Execute(projectId);
            return Ok(statements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            string? userId = User.Id();
            if (userId == null) return Unauthorized();
            StatementModel statement = await _getStatementQuery.Execute(id, userId);
            return Ok(statement);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create(long id, [FromBody] CreateStatementModel statement)
        {
            long? result = await _createCommand.Execute(id, statement);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatement(long id, [FromBody] UpdateStatementModel updates)
        {
            string? userId = User.Id();
            if (userId == null) return Unauthorized();
            StatementModel statement = await _updateStatementCommand.Execute(id, updates, userId!);
            return Ok(statement);
        }

        [HttpPut("{id}/TechnicalOfficeSubmit")]
        public async Task<IActionResult> TechnicalOfficeSubmit(long id, [FromBody] TechnicalOfficeSubmitModel model)
        {
            StatementModel statement = await _technicalOfficeSubmitCommand.Execute(id, model,User);
            return Ok(statement);
        }
        /*[HttpPut("Submit/{id}")]
        public async Task<IActionResult> UpdateStatementAndSubmit(long id, [FromBody] UpdateStatementModel model)
        {
            var statement = await _updateStatementCommand.Execute(id, model, 0, true);
            return Ok(statement);
        }*/

    }
}
