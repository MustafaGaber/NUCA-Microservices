using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Statements.Queries.PrintStatement;
using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Api.Controllers.Statements
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintStatementController : Controller
    {
        private readonly IPrintStatementQuery _printStatementQuery;
        private readonly IJsReportMVCService _jsReportMVCService;
        public PrintStatementController( IJsReportMVCService jsReportMVCService, IPrintStatementQuery printStatementQuery)
        {
            _jsReportMVCService = jsReportMVCService;
            _printStatementQuery = printStatementQuery;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Print(long id)
        {
            var model = await _printStatementQuery.Execute(id);
            if (model.Statement.State < StatementState.Revision)
            {
                throw new InvalidOperationException();
            }
            var header = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Header", model);
            var footer = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Footer", new { });
            var pdfOperations = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "PdfOperations", model.Statement.Withholdings);
            var content = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Statement", model.Statement);
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
                        MarginBottom = "2.5cm",
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
                                        MarginBottom = "2.5cm",
                                        MarginRight = "1cm",
                                  },
                                  Content = pdfOperations,
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
    }
}
