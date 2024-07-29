using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Register.Controllers.Dictionaries.Banks;

[Route("banks")]
[ApiController]
public class BankController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddBank(
        [FromBody] string name,
        CancellationToken cancellationToken)
    {
        var result = await _bankService.AddBankAsync(name, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
    
    [HttpGet("{id:long}")]
    public async Task<string> GetBank(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _bankService.GetBankAsync(id, cancellationToken);
        return result;
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
}