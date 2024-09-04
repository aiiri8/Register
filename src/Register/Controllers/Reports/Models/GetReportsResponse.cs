using System;
using System.Collections.Immutable;

namespace Register.Controllers.Reports.Models;

public record GetReportsResponse(
    ImmutableArray<string> ReportTitles);