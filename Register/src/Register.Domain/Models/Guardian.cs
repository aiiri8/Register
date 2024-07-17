using System;

namespace Register.Domain.Models;

public record Guardian(
    long? Id,
    string FirstName,
    string LastName,
    string Patronymic,
    DateTime Birthday,
    Sex Sex,
    string Inn,
    string Snils,
    DocumentType DocumentType,
    string DocumentSeries,
    string DocumentNumber,
    Bank Bank,
    string RecipientAccount,
    DateTime OpeningDate,
    IssuingAuthority IssuingAuthority,
    DateTime IssuingDate,
    DateTime BeginningDate,
    DateTime EndingDate,
    Territory Territory,
    CalculationMethod CalculationMethod,
    PensionStatus PensionStatus);