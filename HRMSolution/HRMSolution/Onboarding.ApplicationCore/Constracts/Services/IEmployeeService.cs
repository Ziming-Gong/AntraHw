using Onboarding.ApplicationCore.Model;

namespace Onboarding.ApplicationCore.Constracts.Services;

public interface IEmployeeService
{
    Task<int> InsertEmployeeAsync(EmployeeRequestModel model);
    Task<int> UpdateEmployeeAsync(EmployeeRequestModel model);
    Task<int> DeleteEmployeeByIdAsync(int id);
    Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
    Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync();

}