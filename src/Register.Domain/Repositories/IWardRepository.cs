using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Models;

namespace Register.Domain.Repositories;

public interface IWardRepository
{
    public Task<long> Add(
        Ward command,
        CancellationToken cancellationToken);

    public Task<long> Update(
        long id,
        Ward command,
        CancellationToken cancellationToken);
    
    Task<Ward> Get(
        long id,
        CancellationToken cancellationToken);
    
    Task<ImmutableHashSet<Ward>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken);
    
    Task<ImmutableHashSet<Ward>> Get(
        string query,
        CancellationToken cancellationToken);
}