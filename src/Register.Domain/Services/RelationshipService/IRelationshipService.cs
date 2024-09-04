using System;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddRelationship;
using Register.Domain.Features.GetRelationship;
using Register.Domain.Features.GetRelationships;
using Register.Domain.Models;

namespace Register.Domain.Services.RelationshipService;

public interface IRelationshipService
{
    Task<AddRelationshipResult> AddRelationshipAsync(
        Relationship command,
        CancellationToken cancellationToken);
    
    public Task<GetRelationshipResult> GetRelationshipAsync(
        long id,
        CancellationToken cancellationToken);
    
    public Task<GetRelationshipsResult> GetRelationshipsAsync(
        long guardianId,
        CancellationToken cancellationToken);

    public Task<AddRelationshipResult> UpdateRelationshipAsync(
        long id,
        long DaysInMonth,
        DateTime EndingDate,
        CancellationToken cancellationToken);
}