using User.ApplicationCore.Entity;

namespace User.ApplicationCore.Models;

public class RoleRequestModel
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
}