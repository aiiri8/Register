using Register.Domain.Models;

namespace Register.Domain.Features.GetRelationship;

public record GetRelationshipResult(
    Relationship Relationship,
    Ward Ward);