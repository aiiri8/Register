using System.Collections.Generic;
using System.Collections.Immutable;

namespace Register.Domain.Features.GetReportData;

public record GetReportDataResult(
    bool IsSuccess,
    ImmutableArray<ReportRow> Rows)
{
    public GetReportDataResult(ImmutableArray<ReportRow> rows) : this(true, rows)
    {
    }
}