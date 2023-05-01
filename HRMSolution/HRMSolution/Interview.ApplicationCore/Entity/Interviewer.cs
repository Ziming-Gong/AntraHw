using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Entity;

public class Interviewer
{
    public int InterviewerId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string LastName { get; set; }
    public int EmployeeId { get; set; }
    
    
    public List<Interview> Interviews { get; set; }
}