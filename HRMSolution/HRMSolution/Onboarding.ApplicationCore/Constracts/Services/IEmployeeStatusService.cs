using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model;

namespace Onboarding.ApplicationCore.Constracts.Services;

public interface IEmployeeStatusService
{
    Task<int> InsertEmployeeStatusAsync(EmployeeStatusRequestModel model);
    Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model);
    Task<int> DeleteEmployeeStatusByIdAsync(int id);
    Task<EmployeeStatusResponseModel> GetEmployeeStatusById(int id);
    Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync();
}