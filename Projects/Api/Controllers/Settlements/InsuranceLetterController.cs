using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Settlements.Queries.GetSettlement;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Api.Controllers.Settlements
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceLetterController : BaseController
    {
        private readonly IGetSettlementQuery _getSettlementQuery;
        private readonly IJsReportMVCService _jsReportMVCService;

        public InsuranceLetterController(IGetSettlementQuery getSettlementQuery, IJsReportMVCService jsReportMVCService)
        {
            _getSettlementQuery = getSettlementQuery;
            _jsReportMVCService = jsReportMVCService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            Settlement settlement = await _getSettlementQuery.Execute(id) ?? throw new NullReferenceException();
            if (!settlement.Submitted)
            {
                throw new InvalidOperationException();
            }
            var content = await _jsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "InsuranceLetter.cshtml", settlement);
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
