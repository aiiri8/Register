namespace Register.Domain.Features.AddDocumentType;

public record AddDocumentTypeResult(
    bool IsSuccess,
    long Id)
{
    public AddDocumentTypeResult(long id) : this(true, id)
    {
    }
}