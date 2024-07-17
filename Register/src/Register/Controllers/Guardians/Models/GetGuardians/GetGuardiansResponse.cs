using System;
using System.Collections.Immutable;

namespace Register.Controllers.Guardians.Models.GetGuardians;

public record GetGuardiansResponse(
    ImmutableArray<GuardianResponse> GuardianResponse);
    
public record GuardianResponse(
    long Id,
    string FirstName,
    string LastName,
    string Patronymic,
    DateTime Birthday,
    string Sex,
    string Inn,
    string Snils,
    string DocumentType,
    string DocumentSeries,
    string DocumentNumber,
    string Bank,
    string RecipientAccount,
    DateTime OpeningDate,
    string IssuingAuthority,
    DateTime IssuingDate,
    DateTime BeginningDate,
    DateTime EndingDate,
    string Territory,
    string CalculationMethod,
    string PensionStatus
);