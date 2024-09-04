using Register.Controllers.Dictionaries.Territories.Models;
using Register.Domain.Features.GetTerritory;
using Register.Domain.Models;

namespace Register.Controllers.Dictionaries.Territories.Mappings;

public static class GetTerritoryMapping
{
    public static TerritoryResponse MapToResponse (
        this GetTerritoryResult result)
    {
        return result.Territory.MapToResponse();
    }

   public static TerritoryResponse MapToResponse(
        this Territory territory)
    {
        return new TerritoryResponse(
            (territory.Id ?? 0),
            territory.TerritoryName);
    }
}