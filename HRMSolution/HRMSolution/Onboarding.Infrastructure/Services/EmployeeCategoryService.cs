using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Exceptions;
using Onboarding.ApplicationCore.Model;
using Onboarding.Infrastructure.Mapper;

namespace Onboarding.Infrastructure.Services;

public class EmployeeCategoryService : IEmployeeCategoryService
{
    private readonly IEmployeeCategoryRepository _categoryRepository;

    public EmployeeCategoryService(IEmployeeCategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> InsertEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
    {
        var exist = await _categoryRepository.GetById(model.LookUpCode);
        if (exist != null)
        {
            throw new HasExistException("EmployeeCategory", "LookUpCode", model.LookUpCode);
        }

        EmployeeCategory employeeCategory = new EmployeeCategory();
        if (model != null)
        {
            // employeeCategory.LookUpCode = model.LookUpCode;
            employeeCategory.Description = model.Description;
            return await _categoryRepository.Insert(employeeCategory);
        }
        else
        {
            return -1;
        }
    }

    public async Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
    {
        var exist = await _categoryRepository.GetById(model.LookUpCode);
        if (exist == null)
        {
            throw new NotFoundException("EmployeeCategory", "LookUpCode", model.LookUpCode);
        }

        EmployeeCategory employeeCategory = new EmployeeCategory();
        if (model != null)
        {
            employeeCategory.LookUpCode = model.LookUpCode;
            employeeCategory.Description = model.Description;
            return await _categoryRepository.Update(employeeCategory);
        }
        else
        {
            return -1;
        }
    }

    public async Task<int> DeleteEmployeeCategoryByIdAsync(int id)
    {
        return await _categoryRepository.DeleteById(id);
    }

    public async Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id)
    {
        var res = await _categoryRepository.GetById(id);
        if (res != null)
        {
            return res.ToEmployeeCategoryResponseModel();
        }
        else
        {
            throw new NotFoundException("EmployeeCategory", "LookUpCode", id);
        }
    }

    public async Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategoryAsync()
    {
        var res = await _categoryRepository.GetAll();
        var response = res.Select(x => x.ToEmployeeCategoryResponseModel());
        return response;
    }
}