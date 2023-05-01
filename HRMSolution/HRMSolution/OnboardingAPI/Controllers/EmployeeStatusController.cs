using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Model;

namespace OnboardingAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class EmployeeStatusController : ControllerBase
{
    private readonly IEmployeeStatusService _employeeStatusService;

    public EmployeeStatusController(IEmployeeStatusService employeeStatusService)
    {
        _employeeStatusService = employeeStatusService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _employeeStatusService.GetAllEmployeeStatusAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _employeeStatusService.GetEmployeeStatusById(id));
    }

    [HttpPost("CreateEmpoyeeStatus")]
    public async Task<IActionResult> CreateStatus(EmployeeStatusRequestModel model)
    {
        return Ok(await _employeeStatusService.InsertEmployeeStatusAsync(model));
    }
    [HttpPut("UpdateEmployeeStatus")]
    public async Task<IActionResult> UpdateStatus(EmployeeStatusRequestModel model)
    {
        return Ok(await _employeeStatusService.UpdateEmployeeStatusAsync(model));
    }

    [HttpDelete("DeleteEmployeeStatus")]
    public async Task<IActionResult> DeleteStatusById(int id)
    {
        return Ok(await _employeeStatusService.DeleteEmployeeStatusByIdAsync(id));
    }
    
    
    
}