namespace Register.Controllers.Guardians.Models.GetGuardians;

public record GetGuardiansRequest(
    int PageNumber = 1,
    int PageSize = 10);