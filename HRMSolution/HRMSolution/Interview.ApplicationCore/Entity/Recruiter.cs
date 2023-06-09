using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Interview.ApplicationCore.Entity;

public class Recruiter
{
    [Key]
    public int RecruiterId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string LastName { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    
    
    public List<Interview> Interviews { get; set; }

}