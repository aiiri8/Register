using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Register.Database;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Infrastructure.Repositories.DocumentTypes;

public class DocumentTypeRepository(ApplicationDbContext applicationDbContext) : IDocumentTypeRepository
{
    public async Task<long> Add(
        string command,
        CancellationToken cancellationToken)
    {
        var dto = command.MapToDto();
        var result = await applicationDbContext.DocumentTypeDtos
            .AddAsync(dto, cancellationToken);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
    
    public async Task<long> Update(
        long id,
        string command,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.DocumentTypeDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        var entity = applicationDbContext.DocumentTypeDtos.Update(dto!).Entity;
        entity.DocumentTypeName = command;
        applicationDbContext.SaveChanges();

        return id;
    }
    
    public async Task<DocumentType> Get(
        long id,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.DocumentTypeDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);
        return dto!.MapToModel();
    }
    
    public async Task<ImmutableHashSet<DocumentType>> Get(
        CancellationToken cancellationToken)
    {
        var dtos = await applicationDbContext.DocumentTypeDtos
            .OrderByDescending(dto => dto.Id)
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => dto.MapToModel()).ToImmutableHashSet();
        return result;
    }
}