using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Register.Database;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Infrastructure.Repositories.Relationships;

public class RelationshipRepository(ApplicationDbContext applicationDbContext) : IRelationshipRepository
{
    public async Task<long> Add(
        Relationship command,
        CancellationToken cancellationToken)
    {
        var dto = command.MapToDto();
        var result = await applicationDbContext.RelationshipDtos
            .AddAsync(dto, cancellationToken);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
    
    public async Task<Relationship> Get(
        long id,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.RelationshipDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);

        return dto!.MapToModel();
    }

    public async Task<ImmutableHashSet<Relationship>> GetRelationships(
        long guardianId,
        CancellationToken cancellationToken)
    {
        var dtos = await applicationDbContext.RelationshipDtos
            .OrderByDescending(dto => dto.Id)
            .Where(dto => dto.GuardianId == guardianId)
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }

    public async Task<long> Update(
        long id,
        long daysInMonth,
        DateTime endingDate,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.RelationshipDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        var entity = applicationDbContext.RelationshipDtos.Update(dto!).Entity;
        entity.EndingDate = endingDate;
        entity.DaysInMonth = daysInMonth;
        applicationDbContext.SaveChanges();

        return id;
    }
    
    public async Task<ImmutableHashSet<Relationship>> GetActive(CancellationToken cancellationToken)
    {
        var dtos = await applicationDbContext.RelationshipDtos
            .OrderByDescending(dto => dto.Id)
            .Where(dto => new DateTime(dto.EndingDate.Year, dto.EndingDate.Month, 1) >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1))
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }
}