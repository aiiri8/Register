using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("banks")]
public class BankDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("bank_name")]
    public required string BankName { get; set; }
}