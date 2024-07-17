using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("territories")]
public class TerritoryDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("territory_name")]
    public required string TerritoryName { get; set; }
}