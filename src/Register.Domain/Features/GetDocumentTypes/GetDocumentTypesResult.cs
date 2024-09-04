using System.Collections.Immutable;
using Register.Domain.Models;

namespace Register.Domain.Features.GetDocumentTypes;

public record GetDocumentTypesResult(
    ImmutableHashSet<DocumentType> DocumentTypes);