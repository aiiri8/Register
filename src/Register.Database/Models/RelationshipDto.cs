using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("relationships")]
public class RelationshipDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("guardian_id")]
    public long GuardianId { get; set; }
    
    [Column("ward_id")]
    public long WardId { get; set; }
    
    [Column("days_in_month")]
    public long DaysInMonth { get; set; }
    
    [Column("ending_date")]
    public DateTime EndingDate { get; set; }
}