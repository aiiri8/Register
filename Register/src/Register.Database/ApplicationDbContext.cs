using Microsoft.EntityFrameworkCore;
using Register.Database.Models;
namespace Register.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<BankDto> BankDtos { get; set; }
    public required DbSet<CalculationMethodDto> CalculationMethodDtos { get; set; }
    public required DbSet<DocumentTypeDto> DocumentTypeDtos { get; set; }
    public required DbSet<GuardianDto> GuardianDtos { get; set; }
    public required DbSet<IssuingAuthorityDto> IssuingAuthorityDtos { get; set; }
    public required DbSet<PensionStatusDto> PensionStatusDtos { get; set; }
    public required DbSet<RelationshipDto> RelationshipDtos { get; set; }
    public required DbSet<SexDto> SexDtos { get; set; }
    public required DbSet<TerritoryDto> TerritoryDtos { get; set; }
    public required DbSet<WardDto> WardDtos { get; set; }
    public required DbSet<UserDto> UserDtos { get; set; }
    public required DbSet<UserRoleDto> UserRoleDtos { get; set; }
}