using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;

namespace UserAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    // GET
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll ()
    {
        return Ok(await _roleService.GetAllRolesAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _roleService.GetRoleByIdAsync(id));
    }
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole(RoleRequestModel model)
    {
        return Ok(await _roleService.CreateRoleAsync(model));
    }

    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole(RoleRequestModel model)
    {
        return Ok(await _roleService.UpdateRoleAsync(model));
    }

    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRoleById(int id)
    {
        return Ok(await _roleService.DeleteRoleByIdAsync(id));
    }
}