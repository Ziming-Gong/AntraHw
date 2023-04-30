using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;

namespace UserAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _userRoleService;
    public UserRoleController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpGet("GetAllUserRole")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userRoleService.GetAllUserRoleAsync());
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _userRoleService.GetUserRoleById(id));
    }

    [HttpPost("CreateUserRole")]
    public async Task<IActionResult> CreateUserRole(UserRoleRequestModel model)
    {
        return Ok((await _userRoleService.CreateUserRole(model)));
    }

    [HttpPut("UpdateUserRole")]
    public async Task<IActionResult> UpdateUserRole(UserRoleRequestModel model)
    {
        return Ok(await _userRoleService.UpdateUserRoleAsync(model));
    }

    [HttpDelete("DeleteUserRole")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _userRoleService.DeleteUserRoleByIdAsync(id));
    }
    
}