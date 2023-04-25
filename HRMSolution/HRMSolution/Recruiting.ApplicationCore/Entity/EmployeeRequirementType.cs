namespace Recruiting.ApplicationCore.Entity;

public class EmployeeRequirementType
{
    public int JobRequirementId { get; set; }
    
    public int EmployeeTypeId { get; set; }

    public JobRequirement JobRequirement { get; set; }
    public EmployeeType EmployeeType { get; set; }
    
}