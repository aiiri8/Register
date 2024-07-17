using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Register.Database;
using Register.Database.Models;
using Register.Domain.Features.AddGuardian;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Infrastructure.Repositories.Guardians;

public class GuardianRepository(ApplicationDbContext applicationDbContext) : IGuardianRepository
{
    public async Task<long> Add(
        AddGuardianQuery command,
        CancellationToken cancellationToken)
    {
        var dto = command.MapToDto();
        var result = await applicationDbContext.GuardianDtos
            .AddAsync(dto, cancellationToken);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
    
    public async Task<Guardian> Get(
        long id,
        CancellationToken cancellationToken)
    {
        var dto = await applicationDbContext.GuardianDtos.FindAsync(
            [id],
            cancellationToken: cancellationToken);

        return MapGuardianToModel(dto!, cancellationToken).Result;
    }
    
    public async Task<ImmutableHashSet<Guardian>> Get(
        int skip,
        int take,
        CancellationToken cancellationToken)
    {
        var dtos = await applicationDbContext.GuardianDtos
            .OrderByDescending(dto => dto.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        var result = dtos.Select(dto => MapGuardianToModel(dto, cancellationToken).Result).ToImmutableHashSet();
        return result;
    }

    private async Task<Guardian> MapGuardianToModel(GuardianDto dto, CancellationToken cancellationToken)
    {
        var sexDto = await applicationDbContext.SexDtos.FindAsync(
            [dto?.SexId],
            cancellationToken: cancellationToken);
        var documentTypeDto = await applicationDbContext.DocumentTypeDtos.FindAsync(
            [dto?.DocumentTypeId],
            cancellationToken: cancellationToken);
        var bankDto = await applicationDbContext.BankDtos.FindAsync(
            [dto?.BankId],
            cancellationToken: cancellationToken);
        var issuingAuthorityDto = await applicationDbContext.IssuingAuthorityDtos.FindAsync(
            [dto?.IssuingAuthorityId],
            cancellationToken: cancellationToken);
        var territoryDto = await applicationDbContext.TerritoryDtos.FindAsync(
            [dto?.TerritoryId],
            cancellationToken: cancellationToken);
        var calculationMethodDto = await applicationDbContext.CalculationMethodDtos.FindAsync(
            [dto?.CalculationMethodId],
            cancellationToken: cancellationToken);
        var pensionStatusDto = await applicationDbContext.PensionStatusDtos.FindAsync(
            [dto?.PensionStatusId],
            cancellationToken: cancellationToken);
        
        return dto!.MapToModel(
            sexDto!,
            documentTypeDto!,
            bankDto!,
            issuingAuthorityDto!,
            territoryDto!,
            calculationMethodDto!,
            pensionStatusDto!);
    }
}