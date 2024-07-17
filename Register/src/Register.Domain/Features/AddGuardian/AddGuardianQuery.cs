using System;

namespace Register.Domain.Features.AddGuardian;

public record AddGuardianQuery(
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
    long BankId,
    string RecipientAccount,
    DateTime OpeningDate,
    long IssuingAuthorityId,
    DateTime IssuingDate,
    DateTime BeginningDate,
    DateTime EndingDate,
    long TerritoryId,
    long CalculationMethodId,
    long PensionStatusId);
