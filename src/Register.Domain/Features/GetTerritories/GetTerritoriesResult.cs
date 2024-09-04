using System.Collections.Immutable;
using Register.Domain.Models;

namespace Register.Domain.Features.GetTerritories;

public record GetTerritoriesResult(
    ImmutableHashSet<Territory> Territories);