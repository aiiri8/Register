using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddGuardian;
using Register.Domain.Models;

namespace Register.Domain.Repositories;

public interface IRelationshipRepository
{
    public Task<long> Add(
        Relationship command,
        CancellationToken cancellationToken);
    
    public Task<Relationship> Get(
        long id,
        CancellationToken cancellationToken);
    
    public Task<ImmutableHashSet<Relationship>> GetRelationships(
        long guardianId,
        CancellationToken cancellationToken);

    public Task<long> Update(
        long id,
        long daysInMonth,
        DateTime endingDate,
        CancellationToken cancellationToken);
}