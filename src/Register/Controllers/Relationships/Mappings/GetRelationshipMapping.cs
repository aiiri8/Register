using Register.Controllers.Relationships.Models;
using Register.Domain.Features.GetRelationship;

namespace Register.Controllers.Relationships.Mappings;

public static class GetRelationshipMapping
{
    public static RelationshipResponse MapToResponse (
        this GetRelationshipResult result)
    {
        return new RelationshipResponse(
            (result.Relationship.Id ?? 0),
            result.Relationship.GuardianId,
            result.Relationship.WardId,
            result.Ward.FirstName,
            result.Ward.LastName,
            result.Ward.Patronymic,
            result.Ward.Birthday,
            result.Ward.Snils,
            result.Relationship.DaysInMonth,
            result.Relationship.EndingDate);
    }
}