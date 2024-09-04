using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddBank;
using Register.Domain.Features.AddDocumentType;
using Register.Domain.Features.GetBank;
using Register.Domain.Features.GetBanks;
using Register.Domain.Features.GetDocumentType;
using Register.Domain.Features.GetDocumentTypes;
using Register.Domain.Repositories;
using Register.Domain.Services.BankService;

namespace Register.Domain.Services.DocumentTypeService;

public class DocumentTypeService(IDocumentTypeRepository documentTypeRepository) : IDocumentTypeService
{
    private readonly IDocumentTypeRepository _documentTypeRepository = documentTypeRepository;

    public async Task<AddDocumentTypeResult> AddDocumentTypeAsync(
        string command,
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeRepository.Add(command, cancellationToken);
        return new AddDocumentTypeResult(result);
    }
    
    public async Task<AddDocumentTypeResult> UpdateDocumentTypeAsync(
        long id,
        string command,
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeRepository.Update(id, command, cancellationToken);
        return new AddDocumentTypeResult(result);
    }

    public async Task<GetDocumentTypeResult> GetDocumentTypeAsync(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeRepository.Get(id, cancellationToken);
        return new GetDocumentTypeResult(result);
    }
    
    public async Task<GetDocumentTypesResult> GetDocumentTypesAsync(
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeRepository.Get(cancellationToken);
        return new GetDocumentTypesResult(result);
    }
}