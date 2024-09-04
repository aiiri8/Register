using Register.Database.Models;
using Register.Domain.Models;

namespace Register.Infrastructure.Repositories.DocumentTypes;

public static class DocumentTypeMapping
{
    public static DocumentType MapToModel(
        this DocumentTypeDto dto)
    {
        return new DocumentType
        (
            dto.Id,
            dto.DocumentTypeName
        );
    }
    
    public static DocumentTypeDto MapToDto(
        this string model)
    {
        return new DocumentTypeDto()
        {
            DocumentTypeName = model
        };
    }
}