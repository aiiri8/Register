using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("users")]
public class UserDto
{
    [Column("id")]
    public long Id { get; set; }
    [Column("email")]
    public long Email { get; set; }
    [Column("password")]
    public required string Password { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("surname")]
    public required string Surname { get; set; }
    [Column("role_id")]
    public short RoleId { get; set; }
}