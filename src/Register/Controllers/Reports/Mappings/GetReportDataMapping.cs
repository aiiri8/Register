using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Builder.Extensions;
using Register.Controllers.Reports.Models;
using Register.Domain.Features.GetReportData;
using ReportRow = Register.Controllers.Reports.Models.ReportRow;

namespace Register.Controllers.Reports.Mappings;

public static class GetReportDataMapping
{
    public static GetReportDataResponse MapToResponse(
        this GetReportDataResult data)
    {
        return Map(data);
    }

    private static GetReportDataResponse Map(GetReportDataResult data)
    {
        var rows = new List<ReportRow>();

        foreach (var domainRow in data.Rows)
        {
            rows.Add(new ReportRow(
                domainRow.FullName,
                domainRow.Birthday,
                domainRow.Inn,
                domainRow.Snils,
                domainRow.Sex,
                domainRow.Bank,
                domainRow.RecipientAccount,
                domainRow.OpeningDate,
                domainRow.DocumentType,
                domainRow.DocumentSeries,
                domainRow.DocumentNumber,
                domainRow.IssuingAuthorityName,
                domainRow.IssuingAuthorityCode,
                domainRow.IssuingDate,
                domainRow.BeginningDate,
                domainRow.EndingDate,
                domainRow.Territory,
                domainRow.CalculationMethod,
                domainRow.Sum,
                domainRow.PensionStatus));
        }

        return new GetReportDataResponse(rows.ToImmutableArray());
    }
}