using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("wardens")]
public class WardDto
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
    public required DateTime Birthday { get; set; }
    
    [Column("snils")]
    public required string Snils { get; set; }
}