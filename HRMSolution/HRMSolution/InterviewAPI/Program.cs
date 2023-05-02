using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Constracts.Services;
using Interview.Infrastructure.Data;
using Interview.Infrastructure.Repositories;
using Interview.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// user logger to should query
// var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
// var optionsBuilder = new DbContextOptionsBuilder<InterviewDbContext>();
// optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("InterviewAPIDb"));
// optionsBuilder.UseLoggerFactory(loggerFactory);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InterviewDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewAPIDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
// Repo injection
builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();

// Service Injection
builder.Services.AddScoped<IRecruiterService, RecruiterService>();

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


