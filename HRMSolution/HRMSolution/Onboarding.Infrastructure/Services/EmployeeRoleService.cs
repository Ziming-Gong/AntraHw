using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Exceptions;
using Onboarding.ApplicationCore.Model;
using Onboarding.Infrastructure.Mapper;

namespace Onboarding.Infrastructure.Services;

public class EmployeeRoleService : IEmployeeRoleService
{
    private readonly IEmployeeRoleRepository _employeeRoleRepository;
    public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository)
    {
        _employeeRoleRepository = employeeRoleRepository;
    }
    public async Task<int> InsertEmployeeRoleAsync(EmployeeRoleRequestModel model)
    {
        var exist = await _employeeRoleRepository.GetById(model.LookUpdCode);
        if (exist != null)
        {
            throw new HasExistException("EmployeeRole", "LookUpCode", model.LookUpdCode);
        }

        EmployeeRole employeeRole = new EmployeeRole();
        if (model != null)
        {
            employeeRole.LookUpdCode = model.LookUpdCode;
            employeeRole.Name = model.Name;
            employeeRole.ABBR = model.ABBR;
            return await _employeeRoleRepository.Insert(employeeRole);
        }
        else
        {
            return -1;
        }

    }

    public async Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
    {
        var exist = await _employeeRoleRepository.GetById(model.LookUpdCode);
        if (exist == null)
        {
            throw new NotFoundException("EmployeeRole", "LookUpCode", model.LookUpdCode);
        }

        EmployeeRole employeeRole = new EmployeeRole();
        if (model != null)
        {
            employeeRole.LookUpdCode = model.LookUpdCode;
            employeeRole.Name = model.Name;
            employeeRole.ABBR = model.ABBR;
            return await _employeeRoleRepository.Update(employeeRole);
        }
        else
        {
            return -1;
        } 
    }

    public async Task<int> DeleteEmployeeRoleByIdAsync(int id)
    {
        return await _employeeRoleRepository.DeleteById(id);
    }

    public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id)
    {
        var employeeRole = await _employeeRoleRepository.GetById(id);
        if (employeeRole != null)
        {
            return employeeRole.ToEmployeeRoleResponseModel();
        }
        else
        {
            throw new NotFoundException("EmployeeRole", "LookUpCode", id);
        }
    }

    public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync()
    {
        var employeeRoles = await _employeeRoleRepository.GetAll();
        var response = employeeRoles.Select(x => x.ToEmployeeRoleResponseModel());
        return response;
    }
}