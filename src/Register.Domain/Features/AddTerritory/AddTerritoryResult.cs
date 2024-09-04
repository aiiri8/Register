namespace Register.Domain.Features.AddTerritory;

public record AddTerritoryResult(
    bool IsSuccess,
    long Id)
{
    public AddTerritoryResult(long id) : this(true, id)
    {
    }
}