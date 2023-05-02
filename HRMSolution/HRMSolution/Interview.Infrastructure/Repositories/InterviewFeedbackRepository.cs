using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Entity;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repositories;

public class InterviewFeedbackRepository : BaseRepository<InterviewFeedback>, IInterviewFeedbackRepository
{
    public InterviewFeedbackRepository(InterviewDbContext context) : base(context)
    {
    }
}