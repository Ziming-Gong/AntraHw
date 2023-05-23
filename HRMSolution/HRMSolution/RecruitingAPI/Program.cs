using JWTAuthenticationsManager;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repository;
using Recruiting.Infrastructure.Service;
using RecruitingAPI.Filters;
using RecruitingAPI.Midderware;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("RecruitingAPIDb");
// Add services to the container.
builder.Services.AddLogging();
// builder.Services.AddScoped<ILogger, ILogger>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//jwt token
builder.Services.AddCustomJwtTokenService();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddDbContext<RecruitingDbContext>(options =>
{
    if (connectionString != null && connectionString.Length > 1)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingAPIDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    
});
//Repo Injection
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<ISubmissionStatusRepository, StatusRepository>();
builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();

//Service Injection
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<ISubmissionStatusService, SubmissionStatusService>();
builder.Services.AddScoped<IJobRequirementService, JobRequirementsService>();

var app = builder.Build();

// Add filter
// builder.Services.AddMvc(options =>
// {
//     options.Filters.Add(new CustomFilter());
// });



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.MapControllers();


app.Run();