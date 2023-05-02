using Microsoft.AspNetCore.Identity;
using User.ApplicationCore.Models;

namespace User.ApplicationCore.Constract.Repositories;

public interface IAuthenticationRepository
{
    Task<IdentityResult> SignUpAsync(SignUpModel model);
    Task<SignInResult> LogInAsync(LoginModel model);
}