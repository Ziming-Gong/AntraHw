using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model;

namespace Onboarding.ApplicationCore.Constracts.Services;

public interface IEmployeeCategoryService
{
    Task<int> InsertEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
    Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
    Task<int> DeleteEmployeeCategoryByIdAsync(int id);
    Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id);
    Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategoryAsync();
}