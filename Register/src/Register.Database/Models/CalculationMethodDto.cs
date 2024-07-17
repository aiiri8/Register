using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("calculation_methods")]
public class CalculationMethodDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("calculation_method_name")]
    public required string CalculationMethodName { get; set; }
}