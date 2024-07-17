using Microsoft.AspNetCore.Mvc;

namespace Register.Controllers.Dictionaries.Banks;

[Route("banks")]
[ApiController]
public class BankController : ControllerBase
{
    /*[HttpPost]
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
    }*/
}