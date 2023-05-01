using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Onboarding.ApplicationCore.Entity;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string LastName{ get; set; }
    [Column(TypeName = "nvarchar(128)")]
    public string? MiddleName{ get; set; }
    [Required]
    [Column(TypeName = "nvarchar(9)")] 
    public string SSN { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EmployeeCategoryCode { get; set; }
    public int EmployeeStatusCode { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string? Address { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(max)")] 
    public string Email { get; set; }
    public int EmployeeRoleId { get; set; }
    
    public EmployeeRole EmployeeRole { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; }
    public EmployeeCategory EmployeeCategory { get; set; }
    
    
    
}