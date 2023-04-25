using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.ApplicationCore.Entity;

namespace User.Infrastructure.Data;

public class UserDbContext :DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
     

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>(ConfigureUserRole);
    }

    private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");
        builder.HasOne(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(b => b.RoleId);
        builder.HasOne(a => a.Account).WithMany(b => b.UserRoles).HasForeignKey(b => b.UserId );
    }
}