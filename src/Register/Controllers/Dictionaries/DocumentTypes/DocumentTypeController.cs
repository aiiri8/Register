using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Dictionaries.Banks.Mappings;
using Register.Controllers.Dictionaries.DocumentTypes.Mappings;
using Register.Controllers.Dictionaries.DocumentTypes.Models.GetDocumentTypes;
using Register.Domain.Services.DocumentTypeService;

namespace Register.Controllers.Dictionaries.DocumentTypes;

[Route("document-types")]
[ApiController]
public class DocumentTypeController(IDocumentTypeService documentTypeService) : ControllerBase
{
    private readonly IDocumentTypeService _documentTypeService = documentTypeService;

    [HttpPost]
    public async Task<IActionResult> AddDocumentType(
        [FromBody] string name,
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeService.AddDocumentTypeAsync(name, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
    
    [HttpGet("{id:long}")]
    public async Task<DocumentTypeResponse> GetDocumentType(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeService.GetDocumentTypeAsync(id, cancellationToken);
        return result.MapToResponse();
    }

    [HttpGet("")]
    public async Task<GetDocumentTypesResponse> GetDocumentTypes(
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeService.GetDocumentTypesAsync(cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateDocumentType(
        [FromRoute] long id,
        [FromBody] string request,
        CancellationToken cancellationToken)
    {
        var result = await _documentTypeService.UpdateDocumentTypeAsync(id, request, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
}