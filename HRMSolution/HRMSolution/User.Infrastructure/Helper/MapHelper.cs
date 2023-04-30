using User.ApplicationCore.Entity;
using User.ApplicationCore.Models;

namespace User.Infrastructure.Helper;

public static class MapHelper
{

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


    public static RoleResponseModel ToRoleResponseModel(this Role role)
    {
        return new RoleResponseModel
        {
            RoleId = role.RoleId,
            Name = role.Name,
            Description = role.Description
        };
    }

    public static UserRoleResponseModel ToUserRoleResponseModel(this UserRole userRole)
    {
        return new UserRoleResponseModel
        {
            Id = userRole.Id,
            RoleId = userRole.RoleId,
            UserId = userRole.UserId
        };
    }
}