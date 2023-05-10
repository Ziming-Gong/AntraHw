using JWTAuthenticationsManager;
using JWTAuthenticationsManager.Models;
using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;

namespace UserAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller
{
    private readonly JWTTokenHandler jwtTokenHandler;
    private readonly IAuthenticationService service;

    public AccountController(JWTTokenHandler jwtTokenHandler, IAuthenticationService service)
    {
        this.jwtTokenHandler = jwtTokenHandler;
        this.service = service;
    }
    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
        var result = await service.SignInAsync(model);
        if (result.Succeeded)
        {
            AuthenticationRequest request = new AuthenticationRequest()
            {
                Username = model.Username,
                Password = model.Password
            };
            var response = jwtTokenHandler.GenerateToken(request, "admin");
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
        return Unauthorized();
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        var result = await service.SignUpAsync(model);
        if (result.Succeeded)
        {
            return Ok("created successfully");
        }
        return BadRequest();
    }

}