using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Entity;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repositories;

public class InterviewerRepository : BaseRepository<Interviewer>, IInterviewerRepository
{
    public InterviewerRepository(InterviewDbContext context) : base(context)
    {
    }
}