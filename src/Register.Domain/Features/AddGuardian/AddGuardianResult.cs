namespace Register.Domain.Features.AddGuardian;

public record AddGuardianResult(
    bool IsSuccess,
    long Id)
{
    public AddGuardianResult(long id) : this(true, id)
    {
    }
}