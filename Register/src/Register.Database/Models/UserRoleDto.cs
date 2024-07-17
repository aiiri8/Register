using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("user_roles")]
public class UserRoleDto
{
    [Column("id")]
    public short Id { get; set; }
    
    [Column("role")]
    public required string Role { get; set; }
}