using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entity;

public class EmployeeCategory
{
    [Key]
    public int LookUpCode{ get; set; }
    [Column(TypeName = "nvarchar(512)")]
    public string Description{ get; set; }
    
    public List<Employee> Employees { get; set; }
    
}