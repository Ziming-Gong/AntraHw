namespace User.ApplicationCore.Models;

public class AccountRequestModel
{
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HashPassWord { get; set; }
    public string Salt { get; set; } 
}