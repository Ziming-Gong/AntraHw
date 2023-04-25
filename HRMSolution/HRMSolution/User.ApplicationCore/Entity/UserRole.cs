using System.ComponentModel.DataAnnotations;

namespace User.ApplicationCore.Entity;

public class UserRole
{
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int RoleId { get; set; }
    
    public Role Role { get; set; }
    public Account Account { get; set; }

}