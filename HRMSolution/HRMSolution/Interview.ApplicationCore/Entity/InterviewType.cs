using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Entity;

public class InterviewType
{
    [Key]
    public int LookUpCode { get; set; }
    [Column(TypeName = "nvarchar(128)")]
    public string? Description { get; set; }
    
    public List<Interview> Interviews { get; set; }

    
}