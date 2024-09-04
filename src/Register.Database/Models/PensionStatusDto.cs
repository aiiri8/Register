using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("pension_statuses")]
public class PensionStatusDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("pension_status_name")]
    public required string PensionStatusName { get; set; }
}