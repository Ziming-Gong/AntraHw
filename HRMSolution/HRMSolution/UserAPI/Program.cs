    using JWTAuthenticationsManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;
using User.Infrastructure.Data;
using User.Infrastructure.Repositories;
using User.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("UserAPIDb");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomJwtTokenService(); // Custom Token
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});
//DB context
builder.Services.AddDbContext<UserDbContext>(options =>
{
    if (connectionString != null && connectionString.Length > 1)
    {
        options.UseSqlServer(connectionString);
    }
    else
    { 
        options.UseSqlServer(builder.Configuration.GetConnectionString("UserAPIDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Repo Injection
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
// Server Injection
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Token
builder.Services.AddSingleton<JWTTokenHandler>();
// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.Run();