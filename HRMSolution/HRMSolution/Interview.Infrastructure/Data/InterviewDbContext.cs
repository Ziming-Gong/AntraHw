using Interview.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Data;

public class InterviewDbContext : DbContext
{
    public InterviewDbContext(DbContextOptions<InterviewDbContext> options) :base(options)
    {
        
    }

    public DbSet<Recruiter> Recruiters { get; set; }
    public DbSet<Interviewer> Interviewers { get; set; }
    public DbSet<ApplicationCore.Entity.Interview> Interviews { get; set; }
    public DbSet<InterviewFeedback> InterviewFeedbacks { get; set; }
    public DbSet<InterviewType> InterviewTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationCore.Entity.Interview>(ConfigureInterview);
    }

    private void ConfigureInterview(EntityTypeBuilder<ApplicationCore.Entity.Interview> builder)
    {
        builder.HasKey(a => a.InterviewId);
        builder.HasOne(a => a.InterviewType).WithMany(b => b.Interviews).HasForeignKey(a => a.InterviewTypeCode);
        builder.HasOne(a => a.Interviewer).WithMany(b => b.Interviews).HasForeignKey(a => a.InterviewerId);
        builder.HasOne(a => a.InterviewFeedback).WithOne(b => b.Interview).HasForeignKey<ApplicationCore.Entity.Interview>(a => a.FeedbackId);
        builder.HasOne(a => a.Recruiter).WithMany(b => b.Interviews).HasForeignKey(a => a.RecruiterId);
    }
}