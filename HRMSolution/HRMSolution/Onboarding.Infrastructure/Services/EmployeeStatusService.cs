using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Exceptions;
using Onboarding.ApplicationCore.Model;
using Onboarding.Infrastructure.Data;
using Onboarding.Infrastructure.Mapper;

namespace Onboarding.Infrastructure.Services;

public class EmployeeStatusService : IEmployeeStatusService
{

    private readonly IEmployeeStatusRepository _employeeStatusRepository;

    public EmployeeStatusService(IEmployeeStatusRepository employeeStatusRepository)
    {
        _employeeStatusRepository = employeeStatusRepository;
    }
    public async Task<int> InsertEmployeeStatusAsync(EmployeeStatusRequestModel model)
    {
        var exist = await _employeeStatusRepository.GetById(model.LookUpCode);
        if (exist != null)
        {
            throw new HasExistException("EmployeeStatus", "LookUpCode", model.LookUpCode);
        }

        EmployeeStatus employeeStatus = new EmployeeStatus();
        if (model != null)
        {
            employeeStatus.LookUpCode = model.LookUpCode;
            employeeStatus.Description = model.Description;
            employeeStatus.ABBR = model.ABBR;
            return await _employeeStatusRepository.Insert(employeeStatus);
        }

        return -1;
    }

    public async Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
    {
        var exist = await _employeeStatusRepository.GetById(model.LookUpCode);
        if (exist == null)
        {
            throw new NotFoundException("EmployeeStatus", "LookUpCode", model.LookUpCode);
        }

        EmployeeStatus employeeStatus = new EmployeeStatus();
        if (model != null)
        {
            employeeStatus.LookUpCode = model.LookUpCode;
            employeeStatus.Description = model.Description;
            employeeStatus.ABBR = model.ABBR;
            return await _employeeStatusRepository.Update(employeeStatus);
        }

        return -1; 
    }

    public async Task<int> DeleteEmployeeStatusByIdAsync(int id)
    {
        return await _employeeStatusRepository.DeleteById(id);
    }

    public async Task<EmployeeStatusResponseModel> GetEmployeeStatusById(int id)
    {
        var employeeStatus = await _employeeStatusRepository.GetById(id);
        if (employeeStatus != null)
        {
            return employeeStatus.ToEmployeeStatusResponseModel();
        }
        else
        {
            throw new NotFoundException("EmployeeStatus", "LookUpCode", id);
        }
    }

    public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync()
    {
        var res = await _employeeStatusRepository.GetAll();
        var response = res.Select(x => x.ToEmployeeStatusResponseModel());
        return response;
    }
}