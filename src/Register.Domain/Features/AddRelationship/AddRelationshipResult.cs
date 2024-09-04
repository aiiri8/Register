namespace Register.Domain.Features.AddRelationship;

public record AddRelationshipResult(
    bool IsSuccess,
    long Id)
{
    public AddRelationshipResult(long id) : this(true, id)
    {
    }
}