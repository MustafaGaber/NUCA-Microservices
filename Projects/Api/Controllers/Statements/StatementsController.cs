using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Statements.Commands.CreateStatement;
using NUCA.Projects.Application.Statements.Commands.UpdateStatement;
using NUCA.Projects.Application.Statements.Queries.PrintStatement;
using NUCA.Projects.Application.Statements.Queries.GetProjectStatements;
using NUCA.Projects.Application.Statements.Queries.GetStatement;
using NUCA.Projects.Application.Statements.Queries.GetUserStatements;
using NUCA.Projects.Domain.Entities.Statements;


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
        public StatementsController(IGetStatementQuery getStatementQuery, IGetCurrentStatementsQuery getCurrentStatementsQuery, IGetProjectStatementsQuery getProjectStatementsQuery, ICreateStatementCommand createCommand, IUpdateStatementCommand updateStatementCommand)
        {
            _getStatementQuery = getStatementQuery;
            _getCurrentStatementsQuery = getCurrentStatementsQuery;
            _getProjectStatementsQuery = getProjectStatementsQuery;
            _createCommand = createCommand;
            _updateStatementCommand = updateStatementCommand;
        }

        [HttpGet("ProjectStatements/{projectId}")]
        public async Task<IActionResult> GetProjectStatements(long projectId)
        {
            var statements = await _getProjectStatementsQuery.Execute(projectId);
            return Ok(statements);
        }

        [HttpGet("CurrentStatements")]
        public async Task<IActionResult> GetCurrentStatements()
        {
            long userId = 1;
            var statements = await _getCurrentStatementsQuery.Execute(userId);
            return Ok(statements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var statement = await _getStatementQuery.Execute(id);
            return Ok(statement);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create(long id, [FromBody] CreateStatementModel statement)
        {
            long? result = await _createCommand.Execute(id, statement);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStatement(long id, [FromBody] UpdateStatementModel updates)
        {
            var statement = await _updateStatementCommand.Execute(id, updates, 0);
            return Ok(statement);
        }

        /*[HttpPut("Submit/{id}")]
        public async Task<IActionResult> UpdateStatementAndSubmit(long id, [FromBody] UpdateStatementModel updates)
        {
            var statement = await _updateStatementCommand.Execute(id, updates, 0, true);
            return Ok(statement);
        }*/

    }
}
