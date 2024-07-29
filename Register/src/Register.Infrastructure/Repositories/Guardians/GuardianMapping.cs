using Register.Database.Models;
using Register.Domain.Features.AddGuardian;
using Register.Domain.Models;

namespace Register.Infrastructure.Repositories.Guardians;

public static class GuardianMapping
{
    public static Guardian MapToModel(
        this GuardianDto dto,
        SexDto sexDto,
        DocumentTypeDto documentTypeDto,
        BankDto bankDto,
        IssuingAuthorityDto issuingAuthorityDto,
        TerritoryDto territoryDto,
        CalculationMethodDto calculationMethodDto,
        PensionStatusDto pensionStatusDto)
    {
        return new Guardian
        (
            dto.Id,
            dto.FirstName,
            dto.LastName,
            dto.Patronymic,
            dto.Birthday,
            new Sex(sexDto.Id, sexDto.SexName),
            dto.Inn,
            dto.Snils,
            new DocumentType(documentTypeDto.Id, documentTypeDto.DocumentTypeName),
            dto.DocumentSeries,
            dto.DocumentNumber,
            new Bank(bankDto.Id, bankDto.BankName),
            dto.RecipientAccount,
            dto.OpeningDate,
            new IssuingAuthority(issuingAuthorityDto.Id, issuingAuthorityDto.IssuingAuthorityName, issuingAuthorityDto.Code),
            dto.IssuingDate,
            dto.BeginningDate,
            dto.EndingDate,
            new Territory(territoryDto.Id, territoryDto.TerritoryName),
            new CalculationMethod(calculationMethodDto.Id, calculationMethodDto.CalculationMethodName),
            new PensionStatus(pensionStatusDto.Id, pensionStatusDto.PensionStatusName)
        );
    }
    
    public static GuardianDto MapToDto(
        this Guardian model)
    {
        return new GuardianDto()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Birthday = model.Birthday,
            SexId = (model.Sex.Id ?? 0),
            Inn = model.Inn,
            Snils = model.Snils,
            DocumentTypeId = (model.DocumentType.Id ?? 0),
            DocumentSeries = model.DocumentSeries,
            DocumentNumber = model.DocumentNumber,
            BankId = model.Bank.Id ?? 0,
            RecipientAccount = model.RecipientAccount,
            OpeningDate = model.OpeningDate,
            IssuingAuthorityId = model.IssuingAuthority.Id ?? 0,
            IssuingDate = model.IssuingDate,
            BeginningDate = model.BeginningDate,
            EndingDate = model.EndingDate,
            TerritoryId = model.Territory.Id ?? 0,
            CalculationMethodId = model.CalculationMethod.Id ?? 0,
            PensionStatusId = model.PensionStatus.Id ?? 0
        };
    }
    
    public static GuardianDto MapToDto(
        this AddGuardianQuery model)
    {
        return new GuardianDto()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Birthday = model.Birthday,
            SexId = model.SexId,
            Inn = model.Inn,
            Snils = model.Snils,
            DocumentTypeId = model.DocumentTypeId,
            DocumentSeries = model.DocumentSeries,
            DocumentNumber = model.DocumentNumber,
            BankId = model.BankId,
            RecipientAccount = model.RecipientAccount,
            OpeningDate = model.OpeningDate,
            IssuingAuthorityId = model.IssuingAuthorityId,
            IssuingDate = model.IssuingDate,
            BeginningDate = model.BeginningDate,
            EndingDate = model.EndingDate,
            TerritoryId = model.TerritoryId,
            CalculationMethodId = model.CalculationMethodId,
            PensionStatusId = model.PensionStatusId
        };
    }
}