using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Interview.ApplicationCore.Entity;

public class Recruiter
{
    public int RecruiterId { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; }
    [Required]
    public int EmployeeId { get; set; }
}