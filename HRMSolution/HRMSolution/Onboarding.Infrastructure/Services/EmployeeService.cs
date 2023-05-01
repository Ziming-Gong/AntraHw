using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Exceptions;
using Onboarding.ApplicationCore.Model;
using Onboarding.Infrastructure.Mapper;

namespace Onboarding.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> InsertEmployeeAsync(EmployeeRequestModel model)
    {
        var exist = await _employeeRepository.GetById(model.EmployeeId);
        if (exist != null)
        {
            throw new HasExistException("Employee", "id", model.EmployeeId);
        }

        Employee employee = new Employee();
        if (model != null)
        {
            employee.EmployeeId = model.EmployeeId;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.MiddleName = model.MiddleName;
            employee.SSN = model.SSN;
            employee.HireDate = model.HireDate;
            employee.EndDate = model.EndDate;
            employee.EmployeeCategoryCode = model.EmployeeCategoryCode;
            employee.EmployeeStatusCode = model.EmployeeStatusCode;
            employee.Address = model.Address;
            employee.Email = model.Email;
            employee.EmployeeRoleId = model.EmployeeRoleId;
            return await _employeeRepository.Insert(employee);
        }
        return -1;
    }

    public async Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
    {
        var exist = await _employeeRepository.GetById(model.EmployeeId);
        if (exist == null)
        {
            throw new NotFoundException("Employee", "id", model.EmployeeId);
        }

        Employee employee = new Employee();
        if (model != null)
        {
            employee.EmployeeId = model.EmployeeId;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.MiddleName = model.MiddleName;
            employee.SSN = model.SSN;
            employee.HireDate = model.HireDate;
            employee.EndDate = model.EndDate;
            employee.EmployeeCategoryCode = model.EmployeeCategoryCode;
            employee.EmployeeStatusCode = model.EmployeeStatusCode;
            employee.Address = model.Address;
            employee.Email = model.Email;
            employee.EmployeeRoleId = model.EmployeeRoleId;
            return await _employeeRepository.Update(employee);
        }
        return -1; 
    }

    public async Task<int> DeleteEmployeeByIdAsync(int id)
    {
        return await _employeeRepository.DeleteById(id);
    }

    public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
    {
        var res = await _employeeRepository.GetById(id);
        if (res != null)
        {
            return res.ToEmployeeResponseModel();
        }
        else
        {
            throw new NotFoundException("Employee", "id", id);
        }
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync()
    {
        var res = await _employeeRepository.GetAll();
        var response = res.Select(x => x.ToEmployeeResponseModel());
        return response;
    }
}