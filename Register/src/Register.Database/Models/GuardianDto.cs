using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("guardians")]
public class GuardianDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("first_name")]
    public required string FirstName { get; set; }
    
    [Column("last_name")]
    public required string LastName { get; set; }
    
    [Column("patronymic")]
    public required string Patronymic { get; set; }

    [Column("birthday")]
    public DateTime Birthday { get; set; }
    
    [Column("sex_id")]
    public long SexId { get; set; }
    
    [Column("inn")]
    public required string Inn { get; set; }
    
    [Column("snils")]
    public required string Snils { get; set; }

    [Column("document_type_id")]
    public long DocumentTypeId { get; set; }
    
    [Column("document_series")]
    public required string DocumentSeries { get; set; }
    
    [Column("document_number")]
    public required string DocumentNumber { get; set; }
    
    [Column("bank_id")]
    public long BankId { get; set; }
    
    [Column("recipient_account")]
    public required string RecipientAccount { get; set; }
    
    [Column("opening_date")]
    public DateTime OpeningDate { get; set; }
    
    [Column("issuing_authority_id")]
    public long IssuingAuthorityId { get; set; }
    
    [Column("issuing_date")]
    public DateTime IssuingDate { get; set; }
    
    [Column("beginning_date")]
    public DateTime BeginningDate { get; set; }
    
    [Column("ending_date")]
    public DateTime EndingDate { get; set; }
    
    [Column("territory_id")]
    public long TerritoryId { get; set; }
    
    [Column("calculation_method_id")]
    public long CalculationMethodId { get; set; }
    
    [Column("pension_status_id")]
    public long PensionStatusId { get; set; }
}