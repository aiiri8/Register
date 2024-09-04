using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Dictionaries.Territories.Mappings;
using Register.Controllers.Dictionaries.Territories.Models;
using Register.Domain.Services.TerritoryService;

namespace Register.Controllers.Dictionaries.Territories;

[Route("territories")]
[ApiController]
public class TerritoryController(ITerritoryService territoryService) : ControllerBase
{
    private readonly ITerritoryService _territoryService = territoryService;

    [HttpPost]
    public async Task<IActionResult> AddTerritory(
        [FromBody] string name,
        CancellationToken cancellationToken)
    {
        var result = await _territoryService.AddTerritoryAsync(name, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
    
    [HttpGet("{id:long}")]
    public async Task<TerritoryResponse> GetTerritory(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _territoryService.GetTerritoryAsync(id, cancellationToken);
        return result.MapToResponse();
    }

    [HttpGet("")]
    public async Task<GetTerritoriesResponse> GetTerritories(
        CancellationToken cancellationToken)
    {
        var result = await _territoryService.GetTerritoriesAsync(cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateTerritory(
        [FromRoute] long id,
        [FromBody] string request,
        CancellationToken cancellationToken)
    {
        var result = await _territoryService.UpdateTerritoryAsync(id, request, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
}