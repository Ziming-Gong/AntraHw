using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository;

public class JobRequirementRepository : BaseRepository<JobRequirement>, IJobRequirementRepository
{
    private readonly RecruitingDbContext _context;
    public JobRequirementRepository(RecruitingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<JobRequirement>> GetJobRequirementIncludeCategory(Expression<Func<JobRequirement, bool>> filter)
    {
        return await _context.JobRequirements.Include("JobCategory").Where(filter).ToListAsync();
    }
}