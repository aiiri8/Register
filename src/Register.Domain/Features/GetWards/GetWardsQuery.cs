namespace Register.Domain.Features.GetWards;

public record GetWardsQuery(
    int PageNumber = 1,
    int PageSize = 10);