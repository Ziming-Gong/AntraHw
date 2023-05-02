using JWTAuthenticationsManager;
using JWTAuthenticationsManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    private readonly IAuthenticationRepository _authenticationRepository;

    // IdentityUser 

    public AccountController(IAccountService service, JWTTokenHandler jwtTokenHandler, IAuthenticationRepository authenticationRepository)
    {
        _accountService = service;
        _jwtTokenHandler = jwtTokenHandler;
        _authenticationRepository = authenticationRepository;
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
    public async Task<IActionResult> Login(LoginModel model)
    {
        var result = await _authenticationRepository.LogInAsync(model);
        if (result.Succeeded)
        {
            AuthenticationRequest request = new AuthenticationRequest()
            {
                Password = model.Password,
                Username = model.Email
            };
            var response = _jwtTokenHandler.GenerateToken(request, "admin");
            if (response == null) return Unauthorized();
            return Ok();  
        }

        return BadRequest();

    }
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        var res = await _authenticationRepository.SignUpAsync(model);
        if (res.Succeeded) return Ok("your account have been created");
        return BadRequest();
    }



}