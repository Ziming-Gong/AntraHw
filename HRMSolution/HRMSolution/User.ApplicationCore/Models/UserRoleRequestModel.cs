using User.ApplicationCore.Entity;

namespace User.ApplicationCore.Models;

public class UserRoleRequestModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    
}