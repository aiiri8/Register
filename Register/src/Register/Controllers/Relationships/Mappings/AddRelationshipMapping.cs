using Register.Controllers.Relationships.Models;
using Register.Domain.Models;

namespace Register.Controllers.Relationships.Mappings;

public static class AddRelationshipMapping
{
    public static Relationship MapToModel(
        this AddRelationshipRequest request,
        long guardianId)
    {
        return new Relationship(
            null,
            guardianId,
            request.WardId,
            request.DaysInMonth,
            request.EndingDate);
    }
}