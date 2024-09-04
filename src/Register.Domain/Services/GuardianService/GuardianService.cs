using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddGuardian;
using Register.Domain.Features.GetGuardian;
using Register.Domain.Features.GetGuardians;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Domain.Services.GuardianService;

public class GuardianService(IGuardianRepository guardianRepository) : IGuardianService
{
    private readonly IGuardianRepository _guardianRepository = guardianRepository;

    public async Task<AddGuardianResult> AddGuardianAsync(
        AddGuardianQuery command,
        CancellationToken cancellationToken)
    {
        var result = await _guardianRepository.Add(command, cancellationToken);
        return new AddGuardianResult(result);
    }
    
    public async Task<AddGuardianResult> UpdateGuardianAsync(
        long id,
        AddGuardianQuery command,
        CancellationToken cancellationToken)
    {
        var result = await _guardianRepository.Update(id, command, cancellationToken);
        return new AddGuardianResult(result);
    }

    public async Task<GetGuardianResult> GetGuardianAsync(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _guardianRepository.Get(id, cancellationToken);
        return new GetGuardianResult(result);
    }
    
    public async Task<GetGuardiansResult> GetGuardiansAsync(
        GetGuardiansQuery query,
        CancellationToken cancellationToken)
    {
        var skip = (query.PageNumber - 1) * query.PageSize;
        var take = query.PageSize;
        var result = await _guardianRepository.Get(skip, take, cancellationToken);
        return new GetGuardiansResult(result);
    }
    
    public async Task<GetGuardiansResult> GetGuardiansAsync(
        string query,
        CancellationToken cancellationToken)
    {
        var result = await _guardianRepository.Get(query, cancellationToken);
        return new GetGuardiansResult(result);
    }
}