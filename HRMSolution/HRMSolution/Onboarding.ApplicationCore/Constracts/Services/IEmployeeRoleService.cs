using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model;

namespace Onboarding.ApplicationCore.Constracts.Services;

public interface IEmployeeRoleService
{
    Task<int> InsertEmployeeRoleAsync(EmployeeRoleRequestModel model);
    Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model);
    Task<int> DeleteEmployeeRoleByIdAsync(int id);
    Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id);
    Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync();
}