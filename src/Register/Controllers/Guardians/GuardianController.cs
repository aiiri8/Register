using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Guardians.Mappings;
using Register.Controllers.Guardians.Models;
using Register.Controllers.Guardians.Models.GetGuardians;
using Register.Domain.Services.GuardianService;

namespace Register.Controllers.Guardians;

[Route("guardians")]
[ApiController]
public class GuardianController(IGuardianService guardianService) : ControllerBase
{
    private readonly IGuardianService _guardianService = guardianService;

    [HttpPost]
    public async Task<IActionResult> AddGuardian(
        [FromBody] AddGuardianRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.MapToModel();
        var result = await _guardianService.AddGuardianAsync(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
    
    [HttpGet("{id:long}")]
    public async Task<GuardianResponse> GetGuardian(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _guardianService.GetGuardianAsync(id, cancellationToken);
        return result.MapToResponse();
    }

    [HttpPut("")]
    public async Task<GetGuardiansResponse> GetGuardians(
        [FromBody] GetGuardiansRequest request,
        CancellationToken cancellationToken)
    {
        var query = request.MapToModel();
        var result = await _guardianService.GetGuardiansAsync(query, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPut("search")]
    public async Task<GetGuardiansResponse> GetGuardians(
        [FromBody] string request,
        CancellationToken cancellationToken)
    {
        var result = await _guardianService.GetGuardiansAsync(request, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateGuardian(
        [FromRoute] long id,
        [FromBody] AddGuardianRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.MapToModel();
        var result = await _guardianService.UpdateGuardianAsync(id, command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
}