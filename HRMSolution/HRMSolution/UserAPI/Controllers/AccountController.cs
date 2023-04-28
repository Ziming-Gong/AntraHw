using JWTAuthenticationsManager;
using JWTAuthenticationsManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;

namespace UserAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly JWTTokenHandler _jwtTokenHandler;

    public AccountController(IAccountService service, JWTTokenHandler jwtTokenHandler)
    {
        _accountService = service;
        _jwtTokenHandler = jwtTokenHandler;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _accountService.GetAllAccountAsync());
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _accountService.GetAccountByIdAsync(id));
    }

    [HttpDelete("DeleteAccount/{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _accountService.DeleteAccountByIdAsync(id));
    }

    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreateAccount(AccountRequestModel model)
    {
        return Ok(await _accountService.CreateAccountAsync(model));
    }

    [HttpPut("UpdateAccount")]
    public async Task<IActionResult> UpdateAccount(AccountRequestModel model)
    {
        return Ok(await _accountService.UpdateAccount(model));
    }

    [HttpPost("CreateToken")]
    public async Task<IActionResult> Login(AuthenticationRequest request)
    {
        var response = _jwtTokenHandler.GenerateToken(request);
        if (response == null) return Unauthorized();
        return Ok();    
    }



}