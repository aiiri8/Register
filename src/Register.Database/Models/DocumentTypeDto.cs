using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.Database.Models;

[Table("document_types")]
public class DocumentTypeDto
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("document_type_name")]
    public required string DocumentTypeName { get; set; }
}