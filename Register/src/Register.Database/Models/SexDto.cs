using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("sexes")]
public class SexDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("sex_name")]
    public required string SexName { get; set; }
}