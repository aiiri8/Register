using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Register.Database;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Infrastructure.Repositories.Banks;

public class BankRepository(ApplicationDbContext applicationDbContext) : IBankRepository
{
    public async Task<long> Add(
        string command,
        CancellationToken cancellationToken)
    {
        var dto = command.MapToDto();
        var result = await applicationDbContext.BankDtos
            .AddAsync(dto, cancellationToken);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
    
    public async Task<long> Update(
        long id,
        string command,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.BankDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        var entity = applicationDbContext.BankDtos.Update(dto!).Entity;
        entity.BankName = command;
        applicationDbContext.SaveChanges();

        return id;
    }
    
    public async Task<Bank> Get(
        long id,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.BankDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        return dto!.MapToModel();
    }
    
    public async Task<ImmutableHashSet<Bank>> Get(
        CancellationToken cancellationToken)
    {
        var dtos = await applicationDbContext.BankDtos
            .OrderByDescending(dto => dto.Id)
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }
}