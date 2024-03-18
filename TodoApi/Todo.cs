using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("todo")]
class Todo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string? Name { get; set; }
    [Column("iscomplete")]
    public bool IsComplete { get; set; }
}
