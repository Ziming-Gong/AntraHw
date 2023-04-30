using User.ApplicationCore.Entity;
using User.ApplicationCore.Models;

namespace User.ApplicationCore.Constract.Services;

public interface IUserRoleService
{
    Task<int> CreateUserRole(UserRoleRequestModel model);
    Task<int> UpdateUserRoleAsync(UserRoleRequestModel model);
    Task<int> DeleteUserRoleByIdAsync(int id);
    Task<UserRoleResponseModel> GetUserRoleById(int id);
    Task<IEnumerable<UserRoleResponseModel>> GetAllUserRoleAsync();
    
}