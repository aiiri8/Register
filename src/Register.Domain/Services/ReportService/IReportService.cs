using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddReport;
using Register.Domain.Features.GetReportData;


namespace Register.Domain.Services.ReportService;

public interface IReportService
{
    Task<AddReportResult> AddReportAsync(
        CancellationToken cancellationToken);
    
    ImmutableArray<string> GetReports(
        CancellationToken cancellationToken);

    GetReportDataResult GetReportData(long year, long month, CancellationToken cancellationToken);
}