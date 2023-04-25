using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository;

public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
{
    private readonly RecruitingDbContext _context;
    public SubmissionRepository(RecruitingDbContext context) : base(context)
    {
        this._context = context;
    }
    
}