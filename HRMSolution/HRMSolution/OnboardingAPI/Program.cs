using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Constracts.Services;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model;
using Onboarding.Infrastructure.Data;
using Onboarding.Infrastructure.Repositories;
using Onboarding.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("OnboardingDb");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine("this is connect string1 :" + connectionString);
//Database
builder.Services.AddDbContext<OnboardingDbContext>(options =>
{
    Console.WriteLine("this is connect string: " + connectionString);
    if (connectionString != null && connectionString.Length > 1)
    {
        options.UseSqlServer(connectionString);
    }
    else
    { 
        options.UseSqlServer(builder.Configuration.GetConnectionString("OnboardingDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Repository Injection
builder.Services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();
builder.Services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
builder.Services.AddScoped<IEmployeeCategoryRepository, EmployeeCategoryRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Service Injection
builder.Services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();
builder.Services.AddScoped<IEmployeeStatusService, EmployeeStatusService>();
builder.Services.AddScoped<IEmployeeCategoryService, EmployeeCategoryService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();