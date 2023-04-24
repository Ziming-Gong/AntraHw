
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.Infrastructure.Data
{
    public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) :base(options)
        {
            
        }

        public DbSet<Candidate> Candidates { get; set; }
        



    }
}