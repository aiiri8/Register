using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Wards.Mappings;
using Register.Controllers.Wards.Models;
using Register.Controllers.Wards.Models.GetWards;
using Register.Domain.Services.WardService;

namespace Register.Controllers.Wards;

[Route("wards")]
[ApiController]
public class WardController(IWardService wardService) : ControllerBase
{
    private readonly IWardService _wardService = wardService;

    [HttpPost]
    public async Task<IActionResult> AddWard(
        [FromBody] AddWardRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.MapToModel();
        var result = await _wardService.AddWardAsync(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
    
    [HttpGet("{id:long}")]
    public async Task<WardResponse> GetWard(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _wardService.GetWardAsync(id, cancellationToken);
        return result.MapToResponse();
    }

    [HttpPut("")]
    public async Task<GetWardsResponse> GetWards(
        [FromBody] GetWardsRequest request,
        CancellationToken cancellationToken)
    {
        var query = request.MapToModel();
        var result = await _wardService.GetWardsAsync(query, cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateWard(
        [FromRoute] long id,
        [FromBody] AddWardRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.MapToModel();
        var result = await _wardService.AddWardAsync(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
}