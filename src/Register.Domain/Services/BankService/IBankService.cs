using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddBank;
using Register.Domain.Features.GetBank;
using Register.Domain.Features.GetBanks;
using Register.Domain.Features.GetWard;
using Register.Domain.Models;

namespace Register.Domain.Services.BankService;

public interface IBankService
{
    Task<AddBankResult> AddBankAsync(
        string command,
        CancellationToken cancellationToken);

    public Task<AddBankResult> UpdateBankAsync(
        long id,
        string command,
        CancellationToken cancellationToken);
    
    public Task<GetBankResult> GetBankAsync(
        long id,
        CancellationToken cancellationToken);
    
    public Task<GetBanksResult> GetBanksAsync(
        CancellationToken cancellationToken);
}