using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Model;

namespace OnboardingAPI.Controllers;

[Route("/api/[controller]")]
public class EmployeeCategoryController : ControllerBase
{
    private readonly IEmployeeCategoryService _employeeCategoryService;

    public EmployeeCategoryController(IEmployeeCategoryService employeeCategoryService)
    {
        _employeeCategoryService = employeeCategoryService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _employeeCategoryService.GetAllEmployeeCategoryAsync());
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _employeeCategoryService.GetEmployeeCategoryByIdAsync(id));
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _employeeCategoryService.DeleteEmployeeCategoryByIdAsync(id));
    }

    [HttpPost("CreateEmployeeCategory")]
    public async Task<IActionResult> CreateEmployeeCategory(EmployeeCategoryRequestModel model)
    {
        return Ok(await _employeeCategoryService.InsertEmployeeCategoryAsync(model));
    }

    [HttpPut("UpdateEmployeeStatus")]
    public async Task<IActionResult> UpdateEmployeeCategory(EmployeeCategoryRequestModel model)
    {
        return Ok(await _employeeCategoryService.UpdateEmployeeCategoryAsync(model));
    }

}