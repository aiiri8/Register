using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddRelationship;
using Register.Domain.Features.AddWard;
using Register.Domain.Features.GetRelationship;
using Register.Domain.Features.GetRelationships;
using Register.Domain.Features.GetWard;
using Register.Domain.Features.GetWards;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Domain.Services.RelationshipService;

public class RelationshipService(
    IRelationshipRepository relationshipRepository,
    IWardRepository wardRepository) : IRelationshipService
{
    private readonly IRelationshipRepository _relationshipRepository = relationshipRepository;
    private readonly IWardRepository _wardRepository = wardRepository;

    public async Task<AddRelationshipResult> AddRelationshipAsync(
        Relationship command,
        CancellationToken cancellationToken)
    {
        var result = await _relationshipRepository.Add(command, cancellationToken);
        return new AddRelationshipResult(result);
    }

    public async Task<GetRelationshipResult> GetRelationshipAsync(
        long id,
        CancellationToken cancellationToken)
    {
        var relationship = await _relationshipRepository.Get(id, cancellationToken);
        var ward = await _wardRepository.Get(relationship.WardId, cancellationToken);
        return new GetRelationshipResult(relationship, ward);
    }
    
    public async Task<GetRelationshipsResult> GetRelationshipsAsync(
        long guardianId,
        CancellationToken cancellationToken)
    {
        List<GetRelationshipResult> results = new();
        var relationships = await _relationshipRepository.GetRelationships(guardianId, cancellationToken);
        foreach (var relationship in relationships)
        {
            var ward = await _wardRepository.Get(relationship.WardId, cancellationToken);
            results.Add(new GetRelationshipResult(relationship, ward));
        }
        return new GetRelationshipsResult(results.ToImmutableHashSet());
    }

    public async Task<AddRelationshipResult> UpdateRelationshipAsync(long id, long DaysInMonth, DateTime EndingDate, CancellationToken cancellationToken)
    {
        var result = await _relationshipRepository.Update(id, DaysInMonth, EndingDate, cancellationToken);
        return new AddRelationshipResult(result);
    }
}