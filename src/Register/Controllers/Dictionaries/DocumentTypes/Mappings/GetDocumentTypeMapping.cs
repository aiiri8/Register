using Register.Controllers.Dictionaries.DocumentTypes.Models.GetDocumentTypes;
using Register.Domain.Features.GetDocumentType;
using Register.Domain.Models;

namespace Register.Controllers.Dictionaries.DocumentTypes.Mappings;

public static class GetDocumentTypeMapping
{
    public static DocumentTypeResponse MapToResponse (
        this GetDocumentTypeResult result)
    {
        return result.DocumentType.MapToResponse();
    }

   public static DocumentTypeResponse MapToResponse(
        this DocumentType documentType)
    {
        return new DocumentTypeResponse(
            (documentType.Id ?? 0),
            documentType.DocumentTypeName);
    }
}