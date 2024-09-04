using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Register.Database;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Infrastructure.Repositories.Wards;

public class WardRepository(ApplicationDbContext applicationDbContext) : IWardRepository
{
    public async Task<long> Add(
        Ward command,
        CancellationToken cancellationToken)
    {
        var dto = command.MapToDto();
        var result = await applicationDbContext.WardDtos
            .AddAsync(dto, cancellationToken);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
    
    public async Task<long> Update(
        long id,
        Ward command,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.WardDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        var entity = applicationDbContext.WardDtos.Update(dto!).Entity;
        entity.FirstName = command.FirstName;
        entity.LastName = command.LastName;
        entity.Patronymic = command.Patronymic;
        entity.Birthday = command.Birthday.Date;
        entity.Snils = command.Snils;
        applicationDbContext.SaveChanges();

        return id;
    }
    
    public async Task<Ward> Get(
        long id,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.WardDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        return dto!.MapToModel();
    }
    
    public async Task<ImmutableHashSet<Ward>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken)
    {
        var dtos = await applicationDbContext.WardDtos
            .OrderByDescending(dto => dto.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }
    
    public async Task<ImmutableHashSet<Ward>> Get(
        string query,
        CancellationToken cancellationToken)
    {
        var dtos = await applicationDbContext.WardDtos
            .OrderByDescending(dto => dto.Id)
            .Where(dto => dto.Snils.ToLower().Contains(query.ToLower()) ||
                          new string($"{dto.LastName} {dto.FirstName} {dto.Patronymic}")
                              .ToLower().Contains(query.ToLower()))
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }
}