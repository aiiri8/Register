using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddReport;


namespace Register.Domain.Services.ReportService;

public interface IReportService
{
    Task<AddReportResult> AddReportAsync(
        CancellationToken cancellationToken);
}