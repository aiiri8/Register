using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("issuing_authorities")]
public class IssuingAuthorityDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("issuing_authority_name")]
    public required string IssuingAuthorityName { get; set; }
}