using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Onboarding.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Onboarding.Infrastructure.Data;

public class OnboardingDbContext : DbContext
{
    public OnboardingDbContext(DbContextOptions<OnboardingDbContext> options) :base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; } 
    public DbSet<EmployeeCategory> EmployeeCategories { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    public DbSet<EmployeeStatus> EmployeeStatus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(ConfigureEmployee);
    }
    private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasOne(a => a.EmployeeCategory).WithMany(b => b.Employees).HasForeignKey(a => a.EmployeeCategoryCode);
        builder.HasOne(a => a.EmployeeRole).WithMany(b => b.Employees).HasForeignKey(a =>a.EmployeeRoleId);
        builder.HasOne(a => a.EmployeeStatus).WithMany(b => b.Employees).HasForeignKey(a => a.EmployeeStatusCode);

    }
}