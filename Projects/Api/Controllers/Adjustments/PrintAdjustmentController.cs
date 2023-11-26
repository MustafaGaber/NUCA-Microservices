using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Adjustments.Queries.GetAdjustment;
using System.Reflection.PortableExecutable;

namespace NUCA.Projects.Api.Controllers.Adjustments
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintAdjustmentController : BaseController
    {
        private readonly IGetAdjustmentQuery _getAdjustmentQuery;
        private readonly IJsReportMVCService _jsReportMVCService;

        public PrintAdjustmentController(IGetAdjustmentQuery getAdjustmentQuery, IJsReportMVCService jsReportMVCService)
        {
            _getAdjustmentQuery = getAdjustmentQuery;
            _jsReportMVCService = jsReportMVCService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var adjustment = await _getAdjustmentQuery.Execute(id);
            var content = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Adjustment", adjustment);
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
                        //DisplayHeaderFooter = true,
                        //HeaderTemplate = header,
                        //FooterTemplate = footer,
                        //MarginTop = "3cm",
                        //MarginBottom = "2.5cm",
                        MarginLeft = "1cm",
                        MarginRight = "1cm",
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
