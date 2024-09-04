using System;
using System.Collections.Immutable;

namespace Register.Controllers.Dictionaries.DocumentTypes.Models.GetDocumentTypes;

public record GetDocumentTypesResponse(
    ImmutableArray<DocumentTypeResponse> DocumentTypeResponses);
    
public record DocumentTypeResponse(
    long Id,
    string DocumentTypeName
);