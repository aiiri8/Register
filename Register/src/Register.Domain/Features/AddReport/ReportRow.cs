using System;
using System.Collections.Generic;

namespace Register.Domain.Features.AddReport;

public record ReportRow(
    string FullName,
    DateTime Birthday,
    string Inn,
    string Snils,
    string Sex,
    string Bank,
    string RecipientAccount,
    DateTime OpeningDate,
    string DocumentType,
    string DocumentSeries,
    string DocumentNumber,
    string IssuingAuthorityName,
    string IssuingAuthorityCode,
    DateTime IssuingDate,
    DateTime BeginningDate,
    DateTime EndingDate,
    string Territory,
    string CalculationMethod,
    decimal Sum,
    string PensionStatus
)
{
    public List<string> GetData()
    {
        return new List<string>()
        {
            FullName,
            Birthday.ToShortDateString(), 
            Inn, 
            Snils, 
            Sex, 
            Bank, 
            RecipientAccount, 
            OpeningDate.ToShortDateString(), 
            DocumentType, 
            DocumentSeries, 
            DocumentNumber, 
            IssuingAuthorityName, 
            IssuingAuthorityCode, 
            IssuingDate.ToShortDateString(), 
            BeginningDate.ToShortDateString(), 
            EndingDate.ToShortDateString(), 
            Territory, 
            CalculationMethod, 
            Sum.ToString(), 
            PensionStatus
        };
    }
}