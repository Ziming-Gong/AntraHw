using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;

namespace UserAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly IAuthenticationRepository _authenticationRepository;
    public RoleController(IRoleService roleService, IAuthenticationRepository authenticationRepository)
    {
        _roleService = roleService;
        _authenticationRepository = authenticationRepository;
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

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        var res = await _authenticationRepository.SignUpAsync(model);
        if (res.Succeeded) return Ok("your account have been created");
        return BadRequest();
    }
}