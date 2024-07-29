using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells;
using Register.Domain.Features.AddReport;
using Register.Domain.Models;
using Register.Domain.Repositories;

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
            var ward = wards.First(wards => wards.Id == relationship.WardId);
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