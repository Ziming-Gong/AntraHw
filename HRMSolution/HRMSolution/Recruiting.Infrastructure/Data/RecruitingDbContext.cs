
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.Infrastructure.Data
{
    public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) :base(options)
        {
            
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        // public DbSe>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submission>(ConfigureSubmission);
            modelBuilder.Entity<EmployeeRequirementType>(ConfigureEmployeeRequireType);
            modelBuilder.Entity<SubmissionStatus>(ConfigureSubmission);
        }

        private void ConfigureSubmission(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("Submission");
            builder.HasKey(a => a.SubmissionId);
            builder.Property(e => e.SubmissionStatusCode).IsRequired();
            builder.HasOne(a => a.Candidate).WithMany(b => b.Submissions).HasForeignKey(a => a.CandidateId);
            builder.HasOne(a => a.JobRequirement).WithMany(b => b.Submissions).HasForeignKey(b => b.SubmissionId);
            builder.HasMany(a => a.SubmissionStatusList).WithOne(b => b.Submission).HasForeignKey(a => a.LookUpCode);

        }

        private void ConfigureEmployeeRequireType(EntityTypeBuilder<EmployeeRequirementType> builder)
        {
            builder.ToTable("EmployeeRequirementType");
            builder.HasKey(a => new{ a.EmployeeTypeId ,  a.JobRequirementId});
            builder.HasOne(a => a.JobRequirement)
                .WithMany(b => b.EmployeeRequirementTypes)
                .HasForeignKey(b => b.JobRequirementId);
            builder.HasOne(a => a.EmployeeType)
                .WithMany(b => b.EmployeeRequirementTypes)
                .HasForeignKey(a => a.EmployeeTypeId);

        }

        private void ConfigureSubmission(EntityTypeBuilder<SubmissionStatus> builder)
        {
            builder.HasKey(e => e.LookUpCode);
        }
    }
}