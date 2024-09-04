using System;
using System.Collections.Immutable;

namespace Register.Controllers.Dictionaries.Territories.Models;

public record GetTerritoriesResponse(
    ImmutableArray<TerritoryResponse> TerritoryResponses);
    
public record TerritoryResponse(
    long Id,
    string TerritoryName
);