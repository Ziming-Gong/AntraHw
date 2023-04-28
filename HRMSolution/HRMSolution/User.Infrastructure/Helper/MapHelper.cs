using User.ApplicationCore.Entity;
using User.ApplicationCore.Models;

namespace User.Infrastructure.Helper;

public static class MapHelper
{

    /*
     * public int UserId { get; set; }
    public int EmployeeId { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HashPassWord { get; set; }
    public string Salt { get; set; }
    
    public List<UserRole> UserRoles { get; set; }
     */
    public static AccountResponseModel ToAccountResponseModel(this Account account)
    {
        return new AccountResponseModel
        {
            UserId = account.UserId,
            EmployeeId = account.EmployeeId,
            Email = account.Email,
            RoleId = account.RoleId,
            FirstName = account.FirstName,
            LastName = account.LastName,
            HashPassWord = account.HashPassWord,
            Salt = account.Salt,
            UserRoles = account.UserRoles
        };
    }
    
}