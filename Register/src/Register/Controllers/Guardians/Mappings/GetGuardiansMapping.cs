using System.Collections.Immutable;
using System.Linq;
using Register.Controllers.Guardians.Models.GetGuardians;
using Register.Domain.Features.GetGuardians;

namespace Register.Controllers.Guardians.Mappings;

public static class GetGuardiansMapping
{
    public static GetGuardiansQuery MapToModel(
        this GetGuardiansRequest request)
    {
        return new GetGuardiansQuery(
            request.PageNumber,
            request.PageSize);
    }

    public static GetGuardiansResponse MapToResponse(
        this GetGuardiansResult result)
    {
        return new GetGuardiansResponse(
            result.Guardians
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }
}