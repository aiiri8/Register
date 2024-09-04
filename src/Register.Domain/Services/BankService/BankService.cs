using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddBank;
using Register.Domain.Features.GetBank;
using Register.Domain.Features.GetBanks;
using Register.Domain.Repositories;

namespace Register.Domain.Services.BankService;

public class BankService(IBankRepository bankRepository) : IBankService
{
    private readonly IBankRepository _bankRepository = bankRepository;

    public async Task<AddBankResult> AddBankAsync(
        string command,
        CancellationToken cancellationToken)
    {
        var result = await _bankRepository.Add(command, cancellationToken);
        return new AddBankResult(result);
    }
    
    public async Task<AddBankResult> UpdateBankAsync(
        long id,
        string command,
        CancellationToken cancellationToken)
    {
        var result = await _bankRepository.Update(id, command, cancellationToken);
        return new AddBankResult(result);
    }

    public async Task<GetBankResult> GetBankAsync(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _bankRepository.Get(id, cancellationToken);
        return new GetBankResult(result);
    }
    
    public async Task<GetBanksResult> GetBanksAsync(
        CancellationToken cancellationToken)
    {
        var result = await _bankRepository.Get(cancellationToken);
        return new GetBanksResult(result);
    }
}