using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entity;

public class EmployeeRole
{
    [Key]
    public int LookUpdCode{ get; set; }
    public string Name{ get; set; }
    [Column(TypeName = "nvarchar(16)")]
    public string ABBR{ get; set; }
    
    public List<Employee> Employees { get; set; }
}