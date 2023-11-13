using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Statements.Commands.CreateStatement;
using NUCA.Projects.Application.Statements.Commands.UpdateStatement;
using NUCA.Projects.Application.Statements.Queries.GetPrintStatement;
using NUCA.Projects.Application.Statements.Queries.GetProjectStatements;
using NUCA.Projects.Application.Statements.Queries.GetStatement;
using NUCA.Projects.Application.Statements.Queries.GetUserStatements;

namespace NUCA.Projects.Api.Controllers.Statements
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementsController : BaseController
    {
        private readonly IGetStatementQuery _getStatementQuery;
        private readonly IGetCurrentStatementsQuery _getCurrentStatementsQuery;
        private readonly IGetProjectStatementsQuery _getProjectStatementsQuery;
        private readonly IGetPrintStatementQuery _getPrintStatementQuery;
        private readonly ICreateStatementCommand _createCommand;
        private readonly IUpdateStatementCommand _updateStatementCommand;
        private readonly IJsReportMVCService _jsReportMVCService;
        public StatementsController(IGetStatementQuery getStatementQuery, IGetCurrentStatementsQuery getCurrentStatementsQuery, IGetProjectStatementsQuery getProjectStatementsQuery, ICreateStatementCommand createCommand, IUpdateStatementCommand updateStatementCommand, IJsReportMVCService jsReportMVCService, IGetPrintStatementQuery getPrintStatementQuery)
        {
            _getStatementQuery = getStatementQuery;
            _getCurrentStatementsQuery = getCurrentStatementsQuery;
            _getProjectStatementsQuery = getProjectStatementsQuery;
            _createCommand = createCommand;
            _updateStatementCommand = updateStatementCommand;
            _jsReportMVCService = jsReportMVCService;
            _getPrintStatementQuery = getPrintStatementQuery;
        }

        [HttpGet("Print/{id}")]
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> Print(long id)
        {
            var model = await _getPrintStatementQuery.Execute(id);
            var header = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Header",model);

            var footer = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Footer", new { });

            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf).Configure((r) =>
            {
                r.Template.Chrome = new Chrome
                {
                    HeaderTemplate = header,
                    DisplayHeaderFooter = true,
                    FooterTemplate = footer,
                    Landscape = true,
                    MarginTop = "2cm",
                    MarginLeft = "1cm",
                    MarginBottom = "1cm",
                    MarginRight = "1cm",
                };
            });

            return View("Statement", model);
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

        [HttpPut("Save/{id}")]
        public async Task<IActionResult> UpdateStatement(long id, [FromBody] UpdateStatementModel updates)
        {
            var statement = await _updateStatementCommand.Execute(id, updates, 0, false);
            return Ok(statement);
        }

        [HttpPut("Submit/{id}")]
        public async Task<IActionResult> UpdateStatementAndSubmit(long id, [FromBody] UpdateStatementModel updates)
        {
            var statement = await _updateStatementCommand.Execute(id, updates, 0, true);
            return Ok(statement);
        }

    }
}
