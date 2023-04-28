using User.ApplicationCore.Models;

namespace User.ApplicationCore.Constract.Services;

public interface IRoleService
{
    Task<int> CreateRoleAsync(RoleRequestModel model);
    Task<int> UpdateRoleAsync(RoleRequestModel model);
    Task<int> DeleteRoleByIdAsync(int id);
    Task<RoleResponseModel> GetRoleByIdAsync(int id);
    Task<IEnumerable<RoleResponseModel>> GetAllRolesAsync();
}