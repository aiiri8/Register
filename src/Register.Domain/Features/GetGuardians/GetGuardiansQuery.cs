namespace Register.Domain.Features.GetGuardians;

public record GetGuardiansQuery(
    int PageNumber = 1,
    int PageSize = 10);