using System.Collections.Immutable;
using System.Linq;
using Register.Controllers.Wards.Models.GetWards;
using Register.Domain.Features.GetWards;

namespace Register.Controllers.Wards.Mappings;

public static class GetWardsMapping
{
    public static GetWardsQuery MapToModel(
        this GetWardsRequest request)
    {
        return new GetWardsQuery(
            request.PageNumber,
            request.PageSize);
    }

    public static GetWardsResponse MapToResponse(
        this GetWardsResult result)
    {
        return new GetWardsResponse(
            result.Wards
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }
}