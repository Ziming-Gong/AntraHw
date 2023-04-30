using JWTAuthenticationsManager;
using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;
using User.Infrastructure.Data;
using User.Infrastructure.Repositories;
using User.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("AuthenticationDb");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomJwtTokenService(); // Custom Token

//DB context
builder.Services.AddDbContext<UserDbContext>(options =>
{
    // if (connectionString.Length > 1)
    // {
    //     options.UseSqlServer(connectionString);
    // }
    // else
    // { 
        options.UseSqlServer(builder.Configuration.GetConnectionString("UserAPIDb"));
    // }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Repo Injection
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

// Server Injection
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

// Token
builder.Services.AddSingleton<JWTTokenHandler, JWTTokenHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();