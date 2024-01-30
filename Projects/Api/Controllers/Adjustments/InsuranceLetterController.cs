using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Adjustments.Queries.GetAdjustment;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Api.Controllers.Adjustments
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceLetterController : BaseController
    {
        private readonly IGetAdjustmentQuery _getAdjustmentQuery;
        private readonly IJsReportMVCService _jsReportMVCService;

        public InsuranceLetterController(IGetAdjustmentQuery getAdjustmentQuery, IJsReportMVCService jsReportMVCService)
        {
            _getAdjustmentQuery = getAdjustmentQuery;
            _jsReportMVCService = jsReportMVCService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            Adjustment adjustment = await _getAdjustmentQuery.Execute(id) ?? throw new NullReferenceException();
            if (!adjustment.Submitted)
            {
                throw new InvalidOperationException();
            }
            var content = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "InsuranceLetter", adjustment);
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
                        DisplayHeaderFooter = false,
                        MarginTop = "4cm",
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
