using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Entity;

public class InterviewFeedback
{
    public int InterviewFeedbackId { get; set; }
    [Required]
    public int Rating { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string? Comment { get; set; }
    
    public Interview Interview { get; set; }

}