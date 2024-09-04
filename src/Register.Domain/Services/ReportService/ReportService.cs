using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells;
using Register.Domain.Features.AddReport;
using Register.Domain.Features.GetReportData;
using Register.Domain.Models;
using Register.Domain.Repositories;
using ReportRow = Register.Domain.Features.AddReport.ReportRow;
using ReportRowGet = Register.Domain.Features.GetReportData.ReportRow;

namespace Register.Domain.Services.ReportService;

public class ReportService(
    IRelationshipRepository relationshipRepository,
    IGuardianRepository guardianRepository,
    IWardRepository wardRepository) : IReportService
{
    private readonly IRelationshipRepository _relationshipRepository = relationshipRepository;
    private readonly IGuardianRepository _guardianRepository = guardianRepository;
    private readonly IWardRepository _wardRepository = wardRepository;

    public async Task<AddReportResult> AddReportAsync(CancellationToken cancellationToken)
    {
        var activeRelationships = await _relationshipRepository.GetActive(cancellationToken);
        var guardianIds = activeRelationships.Select(relationship => relationship.GuardianId).Distinct().ToList();
        var report = new List<ReportRow>();
        foreach (var id in guardianIds)
        {
            var guardian = await _guardianRepository.Get(id, cancellationToken);
            var relationships = activeRelationships.Where(relationship => relationship.GuardianId == id).ToList();
            List<Ward> wards = new();
            foreach (var relationship in relationships)
            {
                var ward = await _wardRepository.Get(relationship.WardId, cancellationToken);
                wards.Add(ward);
            }

            report.Add(CalculateRow(guardian, relationships, wards));
        }

        FillReportWithData(report);
            
        return new AddReportResult( $"report-{DateTime.Now.Year}-{DateTime.Now.Month}.xlsx");
    }

    public ImmutableArray<string> GetReports(CancellationToken cancellationToken)
    {
        DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
        return di.GetFiles("report-????-??.xlsx").Select(file => file.Name).ToImmutableArray();
    }

    public GetReportDataResult GetReportData(long year, long month, CancellationToken cancellationToken)
    {
        DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
        var title = $"report-{year}-{month}.xlsx";
        var files = di.GetFiles(title).ToList();
        
        if (files.Count != 1)
        {
            return new GetReportDataResult(false, new ImmutableArray<ReportRowGet>());
        }

        return ReadData(title);
    }

    private GetReportDataResult ReadData(string title)
    {
        Workbook wb = new Workbook(title);
        Worksheet worksheet = wb.Worksheets[0];
        int rows = worksheet.Cells.MaxDataRow;
        var data = new List<ReportRowGet>();
        for (int i = 1; i < rows; i++)
        {
            var row = new ReportRowGet(
                worksheet.Cells[i, 0].Value.ToString()!,
                worksheet.Cells[i, 1].Value.ToString()!,
                worksheet.Cells[i, 2].Value.ToString()!,
                worksheet.Cells[i, 3].Value.ToString()!,
                worksheet.Cells[i, 4].Value.ToString()!,
                worksheet.Cells[i, 5].Value.ToString()!,
                worksheet.Cells[i, 6].Value.ToString()!,
                worksheet.Cells[i, 7].Value.ToString()!,
                worksheet.Cells[i, 8].Value.ToString()!,
                worksheet.Cells[i, 9].Value.ToString()!,
                worksheet.Cells[i, 10].Value.ToString()!,
                worksheet.Cells[i, 11].Value.ToString()!,
                worksheet.Cells[i, 12].Value.ToString()!,
                worksheet.Cells[i, 13].Value.ToString()!,
                worksheet.Cells[i, 14].Value.ToString()!,
                worksheet.Cells[i, 15].Value.ToString()!,
                worksheet.Cells[i, 16].Value.ToString()!,
                worksheet.Cells[i, 17].Value.ToString()!,
                worksheet.Cells[i, 18].Value.ToString()!,
                worksheet.Cells[i, 19].Value.ToString()!);
            
            data.Add(row);
        }

        return new GetReportDataResult(data.ToImmutableArray());
    }

    private bool FillReportWithData(List<ReportRow> reportRows)
    {
        Workbook wb = new Workbook();
        Worksheet sheet = wb.Worksheets[0];
        
        FillReportWithColumnNames(sheet);

        for (int i = 2; i <= reportRows.Count + 1; i++)
        {
            FillReportWithRow(sheet, i, reportRows[i - 2]);
        }
        
        wb.Save($"report-{DateTime.Now.Year}-{DateTime.Now.Month}.xlsx", SaveFormat.Xlsx);
        return true;
    }

    private bool FillReportWithRow(Worksheet sheet, int row, ReportRow reportRow)
    {
        string columns = "ABCDEFGHIJKLMNOPQRST";

        List<string> data = reportRow.GetData();
        
        for (int i = 0; i < columns.Length; i++)
        {
            Cell cell = sheet.Cells[columns[i] + row.ToString()];
            cell.PutValue(data[i]);
        }

        return true;
    }

    private bool FillReportWithColumnNames(Worksheet sheet)
    {
        string columns = "ABCDEFGHIJKLMNOPQRST";
        
        List<string> columnNames = 
            new() {
                "ФИО", 
                "Дата рождения",
                "ИНН",
                "СНИЛС",
                "Пол",
                "Банк",
                "Счет получателя",
                "Дата открытия",
                "Вид документа УЛ",
                "Серия",
                "Номер",
                "Кем выдан",
                "Когда выдан",
                "Код подразделения",
                "Дата начала",
                "Дата окончания",
                "Территория",
                "Способ расчета",
                "Сумма",
                "Получает страховую пенсию"
            };
        
        for (int i = 0; i < columns.Length; i++)
        {
            Cell cell = sheet.Cells[columns[i] + "1"];
            cell.PutValue(columnNames[i]);
        }

        return true;
    }

    private ReportRow CalculateRow(
        Guardian guardian,
        List<Relationship> relationships,
        List<Ward> wards)
    {
        decimal baseSum = 6125;
        decimal territorySum = new decimal(7177.80);
        decimal northSum = 5127;
        decimal sumForBabies = 429;
        decimal sumForStudents = 1864;
        decimal sumForDisabled = 2175;
        decimal sum = 0;

        foreach (var relationship in relationships)
        {
            var ward = wards.First(ward => ward.Id == relationship.WardId);
            var wardSum = (baseSum + territorySum + northSum + sumForDisabled);
            
            var age = (DateTime.Now.Year - ward.Birthday.Year - 1) + 
                      (((DateTime.Now.Month > ward.Birthday.Month) || 
                        ((DateTime.Now.Month == ward.Birthday.Month) && 
                         (DateTime.Now.Day >= ward.Birthday.Day))) ? 1 : 0);

            if (age < 3)
            {
                wardSum += sumForBabies;
            }

            if (age >= 12)
            {
                wardSum += sumForStudents;
            }

            wardSum = wardSum / DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) *
                      Math.Min(relationship.DaysInMonth, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            sum += wardSum;
        }
        
        return new ReportRow(
            string.Join(' ',  new List<string>() {guardian.FirstName, guardian.LastName, guardian.Patronymic}),
            guardian.Birthday,
            guardian.Inn,
            guardian.Snils,
            guardian.Sex.SexName,
            guardian.Bank.BankName,
            guardian.RecipientAccount,
            guardian.OpeningDate,
            guardian.DocumentType.DocumentTypeName,
            guardian.DocumentSeries,
            guardian.DocumentNumber,
            guardian.IssuingAuthority.IssuingAuthorityName,
            guardian.IssuingAuthority.Code,
            guardian.IssuingDate,
            new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
            new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1),
            guardian.Territory.TerritoryName,
            guardian.CalculationMethod.CalculationMethodName,
            sum,
            guardian.PensionStatus.PensionStatusName
        );
    }
}