using Interview.ApplicationCore.Constracts.Repositories;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repositories;

public class InterviewRepository : BaseRepository<ApplicationCore.Entity.Interview>, IInterviewRepository
{
    public InterviewRepository(InterviewDbContext context) : base(context)
    {
    }
}