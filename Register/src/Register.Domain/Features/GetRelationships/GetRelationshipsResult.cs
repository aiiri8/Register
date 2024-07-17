using System.Collections.Immutable;
using Register.Domain.Features.GetRelationship;

namespace Register.Domain.Features.GetRelationships;

public record GetRelationshipsResult(
    ImmutableHashSet<GetRelationshipResult> Wards);