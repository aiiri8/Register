using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Register.Controllers.Dictionaries.Banks.Mappings;
using Register.Controllers.Dictionaries.Banks.Models.GetBanks;
using Register.Domain.Services.BankService;

namespace Register.Controllers.Dictionaries.Banks;

[Route("banks")]
[ApiController]
public class BankController(IBankService bankService) : ControllerBase
{
    private readonly IBankService _bankService = bankService;

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
    public async Task<BankResponse> GetBank(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _bankService.GetBankAsync(id, cancellationToken);
        return result.MapToResponse();
    }

    [HttpGet("")]
    public async Task<GetBanksResponse> GetBanks(
        CancellationToken cancellationToken)
    {
        var result = await _bankService.GetBanksAsync(cancellationToken);
        return result.MapToResponse();
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateBank(
        [FromRoute] long id,
        [FromBody] string request,
        CancellationToken cancellationToken)
    {
        var result = await _bankService.UpdateBankAsync(id, request, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Id);
        }

        return BadRequest();
    }
}