using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddGuardian;
using Register.Domain.Models;

namespace Register.Domain.Repositories;

public interface IGuardianRepository
{
    public Task<long> Add(
        AddGuardianQuery command,
        CancellationToken cancellationToken);
    
    Task<Guardian> Get(
        long id,
        CancellationToken cancellationToken);
    
    Task<ImmutableHashSet<Guardian>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken);
}