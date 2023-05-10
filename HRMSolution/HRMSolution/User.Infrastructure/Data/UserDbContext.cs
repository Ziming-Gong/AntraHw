using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.ApplicationCore.Entity;
using User.ApplicationCore.Models;

namespace User.Infrastructure.Data;

public class UserDbContext : IdentityDbContext<ApplicationUser>
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
    // public DbSet<Role> Roles { get; set; }
    // public DbSet<Account> Accounts { get; set; }
    // public DbSet<UserRole> UserRoles { get; set; }
     

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
    }

    // private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
    // {
    //     builder.ToTable("UserRole");
    //     builder.HasOne(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(b => b.RoleId);
    //     builder.HasOne(a => a.Account).WithMany(b => b.UserRoles).HasForeignKey(b => b.UserId );
    // }
}