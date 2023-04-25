using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.ApplicationCore.Entity;

public class SubmissionStatus
{
    public int LookUpCode { get; set; }
    [Column(TypeName = "nvarchar(512)")]
    public string? Description { get; set; }
    
    public Submission Submission { get; set; }
}