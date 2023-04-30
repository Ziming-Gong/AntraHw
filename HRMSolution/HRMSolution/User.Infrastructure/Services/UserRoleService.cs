using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Entity;
using User.ApplicationCore.Exceptions;
using User.ApplicationCore.Models;
using User.Infrastructure.Helper;

namespace User.Infrastructure.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;

    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }
    public async Task<int> CreateUserRole(UserRoleRequestModel model)
    {
        var exist = _userRoleRepository.FirstOrDefaultWithInclude(x => x.RoleId == model.RoleId);
        if (exist != null)
        {
            throw new HasExistException("UserRole","id", model.RoleId);
        }

        UserRole userRole = new UserRole();
        if (model != null)
        {
            userRole.RoleId = model.RoleId;
            userRole.UserId = model.UserId;
            userRole.Id = model.Id;
            return await _userRoleRepository.InsertAsync(userRole);
        }
        else
        {
            return -1;
        }
    }

    public async Task<int> UpdateUserRoleAsync(UserRoleRequestModel model)
    {
        var exist = _userRoleRepository.FirstOrDefaultWithInclude(x => x.RoleId == model.RoleId);
        if (exist == null)
        {
            throw new NotFoundException("UserRole", model.RoleId);
        }

        UserRole userRole = new UserRole();
        if (model != null)
        {
            userRole.RoleId = model.RoleId;
            userRole.UserId = model.UserId;
            userRole.Id = model.Id;
            return await _userRoleRepository.Update(userRole);
        }
        else
        {
            return -1;
        }
    }

    public async Task<int> DeleteUserRoleByIdAsync(int id)
    {
        return await _userRoleRepository.DeleteById(id);
    }

    public async Task<UserRoleResponseModel> GetUserRoleById(int id)
    {
        var res = await _userRoleRepository.GetById(id);
        if (res != null)
        {
            var response = res.ToUserRoleResponseModel();
            return response;
        }
        else
        {
            throw new NotFoundException("UserRole", id);
        }
    }

    public async Task<IEnumerable<UserRoleResponseModel>> GetAllUserRoleAsync()
    {
        var res = await _userRoleRepository.GetAll();
        var response = res.Select(x => x.ToUserRoleResponseModel());
        return response;
    }
}