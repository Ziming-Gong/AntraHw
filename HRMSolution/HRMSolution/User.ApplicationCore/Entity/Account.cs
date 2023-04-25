using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace User.ApplicationCore.Entity;

public class Account
{
    [Key]
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; }
    [Required]
    public int RoleId { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; }
    [Required]
    [Column(TypeName = "varchar(18)")]
    public string HashPassWord { get; set; }
    public string Salt { get; set; }
    
    public List<UserRole> UserRoles { get; set; }
    
}