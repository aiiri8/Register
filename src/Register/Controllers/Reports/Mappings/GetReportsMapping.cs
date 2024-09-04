using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Register.Controllers.Reports.Models;

namespace Register.Controllers.Reports.Mappings;

public static class GetReportsMapping
{
    public static GetReportsResponse MapToResponse(
        this ImmutableArray<string> titles)
    {
        return new GetReportsResponse(titles);
    }
}