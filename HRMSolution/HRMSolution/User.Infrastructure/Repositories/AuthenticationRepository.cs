using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Models;

namespace User.Infrastructure.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    public AuthenticationRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        return await userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role)
    {
        var result = await CreateAsync(user, password);
        if (result != null && result.Succeeded)
        {
            return await userManager.AddToRoleAsync(user, role);
        }
        return result;
    }

    public async Task<SignInResult> SignInAsync(string username, string password)
    {
        return await signInManager.PasswordSignInAsync(username, password, false, false);
    }
}