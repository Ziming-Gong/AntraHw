namespace Recruiting.ApplicationCore.Models;

public class JobRequirementResponseModel
{
    public int JobRequirementId { get; set; } // PK
    public int NumberOfPositions { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public int HiringManagerId { get; set; }// FK
    public string? HiringManagerName { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ClosedOn { get; set; }
    public string? ClosedReason { get; set; }
    public DateTime CreatOn { get; set; }
}