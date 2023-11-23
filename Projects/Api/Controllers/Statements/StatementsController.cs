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
        private readonly IPrintStatementQuery _printStatementQuery;
        private readonly ICreateStatementCommand _createCommand;
        private readonly IUpdateStatementCommand _updateStatementCommand;
        private readonly IJsReportMVCService _jsReportMVCService;
        public StatementsController(IGetStatementQuery getStatementQuery, IGetCurrentStatementsQuery getCurrentStatementsQuery, IGetProjectStatementsQuery getProjectStatementsQuery, ICreateStatementCommand createCommand, IUpdateStatementCommand updateStatementCommand, IJsReportMVCService jsReportMVCService, IPrintStatementQuery printStatementQuery)
        {
            _getStatementQuery = getStatementQuery;
            _getCurrentStatementsQuery = getCurrentStatementsQuery;
            _getProjectStatementsQuery = getProjectStatementsQuery;
            _createCommand = createCommand;
            _updateStatementCommand = updateStatementCommand;
            _jsReportMVCService = jsReportMVCService;
            _printStatementQuery = printStatementQuery;
        }

        [HttpGet("Print/{id}")]
        //[MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> Print(long id)
        {
            var model = await _printStatementQuery.Execute(id);
            var header = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Header", model);
            var footer = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Footer", new { });
            var content = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Statement", model);
            var rs = new LocalReporting().UseBinary(JsReportBinary.GetBinary()).AsUtility().Create();
            var report = await rs.RenderAsync(new RenderRequest()
            {
                Data = model,
                Template = new Template()
                {
                    Recipe = Recipe.ChromePdf,
                    Engine = Engine.Handlebars,
                    Content = content,
                    Chrome = new Chrome()
                    {
                        DisplayHeaderFooter = true,
                        HeaderTemplate = header,
                        FooterTemplate = footer,
                        Landscape = true,
                        MarginTop = "3cm",
                        MarginLeft = "1cm",
                        MarginBottom = "2cm",
                        MarginRight = "1cm",
                    },
                    PdfOperations =
                    new List<PdfOperation> {
                        new PdfOperation()
                        {
                            Type = PdfOperationType.Merge,
                            MergeWholeDocument = true,
                            Template = new Template()
                              {
                                  Recipe = Recipe.ChromePdf,
                                  Engine = Engine.Handlebars,
                                  Chrome = new Chrome()
                                  {
                                        Landscape = true,
                                        MarginTop = "2.5cm",
                                        MarginLeft = "1cm",
                                        MarginBottom = "2cm",
                                        MarginRight = "1cm",
                                  },
                                  Content =
                                  @"{{#each $pdf.pages}}
                                        <div dir=""rtl"">
                                            {{#if 1}}
                                              <div style=""page-break-before: always;""></div>
                                            {{/if}}     
                                            {{group}}
                                        </div>
                                    {{/each}}",
                                },
                            },
                    },
                },
            });
            var memoryStream = new MemoryStream();
            await report.Content.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(memoryStream, "application/pdf");
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
