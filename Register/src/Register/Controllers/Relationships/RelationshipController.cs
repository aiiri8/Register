using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Relationships.Mappings;
using Register.Controllers.Relationships.Models;
using Register.Controllers.Wards.Mappings;
using Register.Controllers.Wards.Models;
using Register.Controllers.Wards.Models.GetWards;
using Register.Domain.Services.RelationshipService;

namespace Register.Controllers.Relationships;

[Route("relationships")]
[ApiController]
public class RelationshipController(IRelationshipService relationshipService) : ControllerBase
{
    private readonly IRelationshipService _relationshipService = relationshipService;

    [HttpPost("/by-guardian/{guardianId:long}")]
    public async Task<IActionResult> AddRelationship(
        long guardianId,
        [FromBody] AddRelationshipRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.MapToModel(guardianId);
        var result = await _relationshipService.AddRelationshipAsync(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
    
    [HttpGet("/by-id/{id:long}")]
    public async Task<RelationshipResponse> GetRelationship(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _relationshipService.GetRelationshipAsync(id, cancellationToken);
        return result.MapToResponse();
    }

    [HttpGet("/by-guardian/{guardianId:long}")]
    public async Task<GetRelationshipsResponse> GetRelationships(
        long guardianId,
        CancellationToken cancellationToken)
    {
        var result = await _relationshipService.GetRelationshipsAsync(guardianId, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPut("/by-id/{id:long}")]
    public async Task<IActionResult> UpdateWard(
        [FromRoute] long id,
        [FromBody] UpdateRelationshipRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _relationshipService.
            UpdateRelationshipAsync(id, 
                request.DaysInMonth, 
                request.EndingDate, 
                cancellationToken);
        
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
}