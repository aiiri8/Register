using System;

namespace Register.Controllers.Guardians.Models;

public record AddGuardianRequest(
    string FirstName,
    string LastName,
    string Patronymic,
    DateTime Birthday,
    long SexId,
    string Inn,
    string Snils,
    long DocumentTypeId,
    string DocumentSeries,
    string DocumentNumber,
    int BankId,
    string RecipientAccount,
    DateTime OpeningDate,
    long IssuingAuthorityId,
    DateTime IssuingDate,
    DateTime BeginningDate,
    DateTime EndingDate,
    long TerritoryId,
    long CalculationMethodId,
    long PensionStatusId);