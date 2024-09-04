using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Models;

namespace Register.Domain.Repositories;

public interface IBankRepository
{
    public Task<long> Add(
        string command,
        CancellationToken cancellationToken);

    public Task<long> Update(
        long id,
        string command,
        CancellationToken cancellationToken);
    
    Task<Bank> Get(
        long id,
        CancellationToken cancellationToken);
    
    Task<ImmutableHashSet<Bank>> Get(
        CancellationToken cancellationToken);
}