using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository;

public class CandidateRepositoryAsync : BaseRepository<Candidate>, ICandidateRepositoryAsync
{
    private readonly RecruitingDbContext _context;
    public CandidateRepositoryAsync(RecruitingDbContext _context ): base(_context)
    {
        this._context = _context;
    }
}