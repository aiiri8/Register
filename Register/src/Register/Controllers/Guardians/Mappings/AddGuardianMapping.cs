using Register.Controllers.Guardians.Models;
using Register.Domain.Features.AddGuardian;
using Register.Domain.Models;

namespace Register.Controllers.Guardians.Mappings;

public static class AddGuardianMapping
{
    public static AddGuardianQuery MapToModel(
        this AddGuardianRequest request)
    {
        return new AddGuardianQuery(
            request.FirstName,
            request.LastName,
            request.Patronymic,
            request.Birthday,
            request.SexId,
            request.Inn,
            request.Snils,
            request.DocumentTypeId,
            request.DocumentSeries,
            request.DocumentNumber,
            request.BankId,
            request.RecipientAccount,
            request.OpeningDate,
            request.IssuingAuthorityId,
            request.IssuingDate,
            request.BeginningDate,
            request.EndingDate,
            request.TerritoryId,
            request.CalculationMethodId,
            request.PensionStatusId);
    }
}