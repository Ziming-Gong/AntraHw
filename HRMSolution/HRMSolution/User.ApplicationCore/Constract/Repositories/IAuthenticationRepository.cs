using Microsoft.AspNetCore.Identity;
using User.ApplicationCore.Models;

namespace User.ApplicationCore.Constract.Repositories;

public interface IAuthenticationRepository
{
    Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role);
    Task<SignInResult> SignInAsync(string username, string password);
}