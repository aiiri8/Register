using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddBank;
using Register.Domain.Features.AddDocumentType;
using Register.Domain.Features.GetBank;
using Register.Domain.Features.GetBanks;
using Register.Domain.Features.GetDocumentType;
using Register.Domain.Features.GetDocumentTypes;
using Register.Domain.Features.GetWard;
using Register.Domain.Models;

namespace Register.Domain.Services.DocumentTypeService;

public interface IDocumentTypeService
{
    Task<AddDocumentTypeResult> AddDocumentTypeAsync(
        string command,
        CancellationToken cancellationToken);

    public Task<AddDocumentTypeResult> UpdateDocumentTypeAsync(
        long id,
        string command,
        CancellationToken cancellationToken);
    
    public Task<GetDocumentTypeResult> GetDocumentTypeAsync(
        long id,
        CancellationToken cancellationToken);
    
    public Task<GetDocumentTypesResult> GetDocumentTypesAsync(
        CancellationToken cancellationToken);
}