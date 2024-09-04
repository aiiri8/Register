using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Reports.Mappings;
using Register.Controllers.Reports.Models;
using Register.Domain.Services.ReportService;

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
    
    [HttpGet("")]
    public GetReportsResponse GetBanks(
        CancellationToken cancellationToken)
    {
        var result = _reportService.GetReports(cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpGet("{year:long}/{month:long}")]
    public GetReportDataResponse GetReportData(
        long year,
        long month,
        CancellationToken cancellationToken)
    {
        var result = _reportService.GetReportData(year, month, cancellationToken);
        return result.MapToResponse();
    }
}