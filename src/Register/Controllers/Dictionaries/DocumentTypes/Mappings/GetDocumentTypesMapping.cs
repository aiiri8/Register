using System.Collections.Immutable;
using System.Linq;
using Register.Controllers.Dictionaries.Banks.Models.GetBanks;
using Register.Controllers.Dictionaries.DocumentTypes.Mappings;
using Register.Controllers.Dictionaries.DocumentTypes.Models.GetDocumentTypes;
using Register.Domain.Features.GetBanks;
using Register.Domain.Features.GetDocumentTypes;

namespace Register.Controllers.Dictionaries.Banks.Mappings;

public static class GetDocumentTypesMapping
{
    public static GetDocumentTypesResponse MapToResponse(
        this GetDocumentTypesResult result)
    {
        return new GetDocumentTypesResponse(
            result.DocumentTypes
                .Select(item => item.MapToResponse())
                .ToImmutableArray());
    }
}