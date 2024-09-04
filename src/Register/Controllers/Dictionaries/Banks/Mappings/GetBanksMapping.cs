using System.Collections.Immutable;
using System.Linq;
using Register.Controllers.Dictionaries.Banks.Models.GetBanks;
using Register.Domain.Features.GetBanks;

namespace Register.Controllers.Dictionaries.Banks.Mappings;

public static class GetBanksMapping
{
    public static GetBanksResponse MapToResponse(
        this GetBanksResult result)
    {
        return new GetBanksResponse(
            result.Banks
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }
}