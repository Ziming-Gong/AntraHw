using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repository;
using Recruiting.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("RecruitingAPIDb");
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RecruitingDbContext>(options =>
{
    // if (connectionString.Length > 1)
    // {
        // options.UseSqlServer(connectionString);
    // }
    // else
    // {
    options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingAPIDb"));
    // }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    
});
//Repo Injection
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();


//Service Injection
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();


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