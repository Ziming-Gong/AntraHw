using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Entity;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repositories;

public class RecruiterRepository : BaseRepository<Recruiter>, IRecruiterRepository
{
    public RecruiterRepository(InterviewDbContext dbContext) :base(dbContext)
    {
        
    }
    
}