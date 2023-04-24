using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.ApplicationCore.Entity;

public class JobRequirement
{
    public int JobRequirementId { get; set; }
    
    public int NumberOfPositions { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(512")]
    public string Title { get; set; }
    [Column(TypeName = "varchar(512)")]
    public string Description { get; set; }
    
    public int HiringManagerId { get; set; }
    
    public string? HiringManagerName { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public bool IsActive { get; set; }

    public DateTime ClosedOn { get; set; }
    
    public string? ClosedReason { get; set; }
    
    public DateTime CreatOn { get; set; }
    
    public JobCategory? JobCategory { get; set; }
    
    public EmployeeType? EmployeeType { get; set; }
    

}