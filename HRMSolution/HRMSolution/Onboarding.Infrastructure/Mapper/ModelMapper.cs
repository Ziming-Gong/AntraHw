using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model;

namespace Onboarding.Infrastructure.Mapper;

public static class ModelMapper
{
    public static EmployeeResponseModel ToEmployeeResponseModel(this Employee employee)
    {
        return new EmployeeResponseModel
        {
            Address = employee.Address,
            Email = employee.Email,
            EmployeeCategoryCode = employee.EmployeeCategoryCode,
            EmployeeId = employee.EmployeeId,
            EmployeeRoleId = employee.EmployeeRoleId,
            EmployeeStatusCode = employee.EmployeeStatusCode,
            EndDate = employee.EndDate,
            FirstName = employee.FirstName,
            HireDate = employee.HireDate,
            LastName = employee.LastName,
            MiddleName = employee.MiddleName,
            SSN = employee.SSN
        };
    }

    public static EmployeeCategoryResponseModel ToEmployeeCategoryResponseModel(this EmployeeCategory employeeCategory)
    {
        return new EmployeeCategoryResponseModel
        {
            LookUpCode = employeeCategory.LookUpCode,
            Description = employeeCategory.Description
        };
    }

    public static EmployeeRoleResponseModel ToEmployeeRoleResponseModel(this EmployeeRole employeeRole)
    {
        return new EmployeeRoleResponseModel
        {
            ABBR = employeeRole.ABBR,
            LookUpdCode = employeeRole.LookUpdCode,
            Name = employeeRole.Name
        };
    }

    public static EmployeeStatusResponseModel ToEmployeeStatusResponseModel(this EmployeeStatus employeeStatus)
    {
        return new EmployeeStatusResponseModel
        {
            ABBR = employeeStatus.ABBR,
            Description = employeeStatus.Description,
            LookUpCode = employeeStatus.LookUpCode
        };
    }
}