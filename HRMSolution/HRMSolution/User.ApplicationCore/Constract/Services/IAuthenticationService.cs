using Microsoft.AspNetCore.Identity;
using User.ApplicationCore.Models;

namespace User.ApplicationCore.Constract.Services;

public interface IAuthenticationService
{
    Task<SignInResult> SignInAsync(SignInModel model);
    Task<IdentityResult> SignUpAsync(SignUpModel model);
    Task<IdentityResult> SignUpAsync(SignUpModel model, string role);
}