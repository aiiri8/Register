using System.Collections.Immutable;
using System.Linq;
using Register.Controllers.Relationships.Models;
using Register.Controllers.Wards.Models.GetWards;
using Register.Domain.Features.GetRelationships;
using Register.Domain.Features.GetWards;

namespace Register.Controllers.Relationships.Mappings;

public static class GetRelationshipsMapping
{
    public static GetRelationshipsResponse MapToResponse(
        this GetRelationshipsResult result)
    {
        return new GetRelationshipsResponse(
            result.Wards
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }
}