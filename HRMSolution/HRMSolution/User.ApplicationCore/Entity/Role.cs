using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.ApplicationCore.Entity;

public class Role
{
    public int RoleId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(129)")]
    public string Name { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }
    
    public List<UserRole> UserRoles { get; set; }
}