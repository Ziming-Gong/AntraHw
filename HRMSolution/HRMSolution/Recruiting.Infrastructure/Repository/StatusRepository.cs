using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository;

public class StatusRepository : BaseRepository<SubmissionStatus>, ISubmissionStatusRepository
{
    private readonly RecruitingDbContext _context;

    public StatusRepository(RecruitingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubmissionStatus>> GetStatusByStatus(string status)
    {
        return await _context.Set<SubmissionStatus>().Where(x => x.Description == status).Include(x => x.Submission).ToListAsync();
    }
}