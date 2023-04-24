namespace Recruiting.ApplicationCore.Entity;

public class EmployeeRequirementType
{
    public int CandidateId { get; set; }
    
    public int EmployeeId { get; set; }

    public JobRequirement JobRequirement { get; set; }
    public EmployeeType EmployeeType { get; set; }
    
}