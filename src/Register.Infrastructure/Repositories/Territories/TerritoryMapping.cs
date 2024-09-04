using Register.Database.Models;
using Register.Domain.Models;

namespace Register.Infrastructure.Repositories.Territories;

public static class TerritoryMapping
{
    public static Territory MapToModel(
        this TerritoryDto dto)
    {
        return new Territory
        (
            dto.Id,
            dto.TerritoryName
        );
    }
    
    public static TerritoryDto MapToDto(
        this string model)
    {
        return new TerritoryDto()
        {
            TerritoryName = model
        };
    }
}