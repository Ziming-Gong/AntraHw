using System.ComponentModel.DataAnnotations;

namespace Recruiting.ApplicationCore.Entity;

public class EmployeeType
{
    public int Id { get; set; }
    [Required]
    public string TypeName { get; set; }
    
    public IEnumerable<EmployeeRequirementType> EmployeeRequirementTypes { get; set; }
}