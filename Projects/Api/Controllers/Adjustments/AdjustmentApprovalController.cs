using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Application.Adjustments.Queries.GetAdjustment;

namespace NUCA.Projects.Api.Controllers.Adjustments
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjustmentApprovalController : Controller
    {
        private readonly IGetAdjustmentModelQuery _getAdjustmentQuery;
        private readonly IJsReportMVCService _jsReportMVCService;

        public AdjustmentApprovalController(IGetAdjustmentModelQuery getAdjustmentQuery, IJsReportMVCService jsReportMVCService)
        {
            _getAdjustmentQuery = getAdjustmentQuery;
            _jsReportMVCService = jsReportMVCService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var adjustment = await _getAdjustmentQuery.Execute(id);
            if (!adjustment.Submitted)
            {
                throw new InvalidOperationException();
            }
            var content = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Adjustment", adjustment);
            var footer = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Footer", new { });
            var header = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Header", new { });
            var rs = new LocalReporting().UseBinary(JsReportBinary.GetBinary()).AsUtility().Create();
            var report = await rs.RenderAsync(new RenderRequest()
            {
                Template = new Template()
                {
                    Recipe = Recipe.ChromePdf,
                    Engine = Engine.None,
                    Content = content,
                    Chrome = new Chrome()
                    {
                        DisplayHeaderFooter = true,
                        HeaderTemplate = header,
                        FooterTemplate = footer,
                        MarginTop = "2cm",
                        MarginBottom = "3cm",
                        MarginLeft = "1.8cm",
                        MarginRight = "1.5cm",
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
