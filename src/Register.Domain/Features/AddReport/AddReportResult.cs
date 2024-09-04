namespace Register.Domain.Features.AddReport;

public record AddReportResult(
    bool IsSuccess,
    string FileName)
{
    public AddReportResult(string fileName) : this(true, fileName)
    {
    }
}