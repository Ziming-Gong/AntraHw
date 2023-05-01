using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Model;

namespace OnboardingAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _employeeService.GetAllEmployeeAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _employeeService.GetEmployeeByIdAsync(id));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _employeeService.DeleteEmployeeByIdAsync(id));
    }

    [HttpPost("CreateEmployee")]
    public async Task<IActionResult> CreateEmployee(EmployeeRequestModel model)
    {
        return Ok(await _employeeService.InsertEmployeeAsync(model));
    }

    [HttpPut("UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(EmployeeRequestModel model)
    {
        return Ok(await _employeeService.UpdateEmployeeAsync(model));
    }
}