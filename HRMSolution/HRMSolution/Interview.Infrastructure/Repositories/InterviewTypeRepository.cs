using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Entity;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repositories;

public class InterviewTypeRepository : BaseRepository<InterviewType>, IInterviewTypeRepository
{
    public InterviewTypeRepository(InterviewDbContext context) : base(context)
    {
    }
}