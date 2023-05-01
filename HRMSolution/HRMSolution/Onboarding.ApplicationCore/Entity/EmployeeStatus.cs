using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entity;

public class EmployeeStatus
{
    [Key]
    public int LookUpCode { get; set; }
    [Column(TypeName = "nvarchar(512)")]
    public string? Description{ get; set; }
    [Column(TypeName = "nvarchar(16)")]
    public string? ABBR { get; set; }
    
    public List<Employee> Employees { get; set; }
}