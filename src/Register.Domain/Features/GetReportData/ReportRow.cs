using System;
using System.Collections.Generic;

namespace Register.Domain.Features.GetReportData;

public record ReportRow(
    string FullName,
    string Birthday,
    string Inn,
    string Snils,
    string Sex,
    string Bank,
    string RecipientAccount,
    string OpeningDate,
    string DocumentType,
    string DocumentSeries,
    string DocumentNumber,
    string IssuingAuthorityName,
    string IssuingAuthorityCode,
    string IssuingDate,
    string BeginningDate,
    string EndingDate,
    string Territory,
    string CalculationMethod,
    string Sum,
    string PensionStatus
);