using Interview.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Interview.Infrastructure.Data;

public class InterviewDbContext : DbContext
{
    public InterviewDbContext(DbContextOptions<InterviewDbContext> options) :base(options)
    {
        
    }

    private DbSet<Recruiter> Recruiters { get; set; }
}