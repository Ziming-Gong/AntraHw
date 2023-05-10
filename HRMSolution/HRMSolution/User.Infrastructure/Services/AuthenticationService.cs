using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;

namespace User.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository repository;
    public AuthenticationService(IAuthenticationRepository repository)
    {
        this.repository = repository;
    }

    public async Task<SignInResult> SignInAsync(SignInModel model)
    {
        return await repository.SignInAsync(model.Username, model.Password);
    }

    public async Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        ApplicationUser user = new ApplicationUser()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Email
        };
        return await repository.CreateAsync(user, model.Password);
    }

    public async Task<IdentityResult> SignUpAsync(SignUpModel model, string role)
    {
        ApplicationUser user = new ApplicationUser()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Email
        };
        return await repository.CreateAsync(user, model.Password, role);
    }
}