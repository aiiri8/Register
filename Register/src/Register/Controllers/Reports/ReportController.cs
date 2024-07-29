using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Wards.Mappings;
using Register.Controllers.Wards.Models;
using Register.Controllers.Wards.Models.GetWards;
using Register.Domain.Services.ReportService;
using Register.Domain.Services.WardService;

namespace Register.Controllers.Reports;

[Route("reports")]
[ApiController]
public class ReportController(IReportService reportService) : ControllerBase
{
    private readonly IReportService _reportService = reportService;

    [HttpPost]
    public async Task<IActionResult> AddReport(
        CancellationToken cancellationToken)
    {
        var result = await _reportService.AddReportAsync(cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.FileName);
        }

        return BadRequest();
    }
    
    [ActionName("File")]
    [HttpGet]
    public HttpResponseMessage File()
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        var stream = new System.IO.FileStream("Excel.xlsx", System.IO.FileMode.Open);
        response.Content = new StreamContent(stream);
        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

        return response;
    }
}