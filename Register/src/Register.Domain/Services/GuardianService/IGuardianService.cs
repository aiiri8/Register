using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddGuardian;
using Register.Domain.Features.GetGuardian;
using Register.Domain.Features.GetGuardians;
using Register.Domain.Models;

namespace Register.Domain.Services.GuardianService;

public interface IGuardianService
{
    Task<AddGuardianResult> AddGuardianAsync(
        AddGuardianQuery command,
        CancellationToken cancellationToken);
    
    public Task<GetGuardianResult> GetGuardianAsync(
        long id,
        CancellationToken cancellationToken);
    
    public Task<GetGuardiansResult> GetGuardiansAsync(
        GetGuardiansQuery query,
        CancellationToken cancellationToken);
}