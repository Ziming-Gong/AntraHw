using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model;

namespace OnboardingAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class EmployeeRoleController : ControllerBase
{
    private readonly IEmployeeRoleService _employeeRoleService;

    public EmployeeRoleController(IEmployeeRoleService employeeRoleService)
    {
        _employeeRoleService = employeeRoleService;
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _employeeRoleService.GetEmployeeRoleByIdAsync(id));
    }

    [HttpGet("GetAllEmployeeRole")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _employeeRoleService.GetAllEmployeeRoleAsync());
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _employeeRoleService.DeleteEmployeeRoleByIdAsync(id));
    }

    [HttpPost("CreateEmployeeRole")]
    public async Task<IActionResult> CreateEmployeeRole(EmployeeRoleRequestModel model)
    {
        return Ok(await _employeeRoleService.InsertEmployeeRoleAsync(model));
    }

    [HttpPut("UpdateEmployeeRole")]
    public async Task<IActionResult> UpdateEmployeeRole(EmployeeRoleRequestModel model)
    {
        return Ok(await _employeeRoleService.UpdateEmployeeRoleAsync(model));
    }
    
    
}