using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Models;

namespace User.Infrastructure.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticationRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        ApplicationUser applicationUser = new ApplicationUser()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Email,
            
        };
        return await _userManager.CreateAsync(applicationUser, model.Password);
    }

    public async Task<SignInResult> LogInAsync(LoginModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        return result;
        

    }
}