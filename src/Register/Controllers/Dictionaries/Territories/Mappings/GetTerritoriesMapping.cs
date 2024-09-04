using System.Collections.Immutable;
using System.Linq;
using Register.Controllers.Dictionaries.Territories.Models;
using Register.Domain.Features.GetTerritories;

namespace Register.Controllers.Dictionaries.Territories.Mappings;

public static class GetTerritoriesMapping
{
    public static GetTerritoriesResponse MapToResponse(
        this GetTerritoriesResult result)
    {
        return new GetTerritoriesResponse(
            result.Territories
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }
}