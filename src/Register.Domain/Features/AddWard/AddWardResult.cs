namespace Register.Domain.Features.AddWard;

public record AddWardResult(
    bool IsSuccess,
    long Id)
{
    public AddWardResult(long id) : this(true, id)
    {
    }
}