using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Entity;
using User.ApplicationCore.Exceptions;
using User.ApplicationCore.Models;
using User.Infrastructure.Data;
using User.Infrastructure.Helper;
using User.Infrastructure.Repositories;

namespace User.Infrastructure.Services;

public class RoleService : IRoleService
{

    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<int> CreateRoleAsync(RoleRequestModel model)
    {
        var exist = _roleRepository.FirstOrDefaultWithInclude(x => x.Name == model.Name);
        if (exist != null)
        {
            throw new HasExistException("Role", "RoleName", model.Name);
        }

        Role role = new Role();
        if (model != null)
        {
            role.RoleId = model.RoleId;
            role.Name = model.Name;
            role.Description = model.Description;
            return await _roleRepository.InsertAsync(role);
        }

        return 0;
    }

    public async Task<int> UpdateRoleAsync(RoleRequestModel model)
    {
        var exist = _roleRepository.FirstOrDefaultWithInclude(x => x.Name == model.Name);
        if (exist != null)
        {
            throw new HasExistException("Role", "RoleName", model.Name);
        } 
        Role role = new Role();
        if (model != null)
        {
            role.RoleId = model.RoleId;
            role.Name = model.Name;
            role.Description = model.Description;
            return await _roleRepository.Update(role);
        }

        return 0; 
    }

    public async Task<int> DeleteRoleByIdAsync(int id)
    {
        return await _roleRepository.DeleteById(id);
    }

    public async Task<RoleResponseModel> GetRoleByIdAsync(int id)
    {
        var res = await _roleRepository.GetById(id);
        if (res != null)
        {
            var response = res.ToRoleResponseModel();
            return response;
        }

        throw new Exception("Oops");
    }

    public async Task<IEnumerable<RoleResponseModel>> GetAllRolesAsync()
    {
        var res = await _roleRepository.GetAll();
        var response = res.Select(x => x.ToRoleResponseModel());
        return response;
    }
}