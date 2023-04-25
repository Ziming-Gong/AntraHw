using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository;

public class CandidateRepositoryAsync : BaseRepository<Candidate>, ICandidateRepositoryAsync
{
    private readonly RecruitingDbContext _context;
    public CandidateRepositoryAsync(RecruitingDbContext context ): base(context)
    {
        this._context = context;
    }

    public async Task<Candidate> GetUserByEmailAsync(string email)
    {
        return await _context.Set<Candidate>().Where(x => x.Email == email).FirstOrDefaultAsync();
    }

    public async Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where, params Expression<Func<Candidate, object>>[] includes)
    {
        var query = _context.Set<Candidate>().AsQueryable();
        if (includes != null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return await query.FirstOrDefaultAsync(where);
    }
}