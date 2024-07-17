using Register.Database.Models;
using Register.Domain.Models;

namespace Register.Infrastructure.Repositories.Relationships;

public static class RelationshipMapping
{
    public static Relationship MapToModel(
        this RelationshipDto dto)
    {
        return new Relationship
        (
            dto.Id,
            dto.GuardianId,
            dto.WardId,
            dto.DaysInMonth,
            dto.EndingDate
        );
    }
    
    public static RelationshipDto MapToDto(
        this Relationship model)
    {
        return new RelationshipDto()
        {
            GuardianId = model.GuardianId,
            WardId = model.WardId,
            DaysInMonth = model.DaysInMonth,
            EndingDate = model.EndingDate
        };
    }
}