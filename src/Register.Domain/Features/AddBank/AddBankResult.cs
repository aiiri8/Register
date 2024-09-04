namespace Register.Domain.Features.AddBank;

public record AddBankResult(
    bool IsSuccess,
    long Id)
{
    public AddBankResult(long id) : this(true, id)
    {
    }
}