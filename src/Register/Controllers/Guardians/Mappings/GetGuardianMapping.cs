using Register.Controllers.Guardians.Models.GetGuardians;
using Register.Domain.Features.GetGuardian;
using Register.Domain.Models;

namespace Register.Controllers.Guardians.Mappings;

public static class GetGuardianMapping
{
    public static GuardianResponse MapToResponse (
        this GetGuardianResult result)
    {
        return result.Guardian.MapToResponse();
    }

   public static GuardianResponse MapToResponse(
        this Guardian guardian)
    {
        return new GuardianResponse(
            (guardian.Id ?? 0),
            guardian.FirstName,
            guardian.LastName,
            guardian.Patronymic,
            guardian.Birthday,
            guardian.Sex.SexName,
            guardian.Inn,
            guardian.Snils,
            guardian.DocumentType.DocumentTypeName,
            guardian.DocumentSeries,
            guardian.DocumentNumber,
            guardian.Bank.BankName,
            guardian.RecipientAccount,
            guardian.OpeningDate,
            guardian.IssuingAuthority.IssuingAuthorityName,
            guardian.IssuingDate,
            guardian.BeginningDate,
            guardian.EndingDate,
            guardian.Territory.TerritoryName,
            guardian.CalculationMethod.CalculationMethodName,
            guardian.PensionStatus.PensionStatusName);
    }
}