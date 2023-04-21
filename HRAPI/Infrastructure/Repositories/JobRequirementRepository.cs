using System;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class JobRequirementRepository : BaseRepository<JobRequirement>, IJobRequirementRepository
	{
		public JobRequirementRepository(RecruitingDbContext context) : base(context)
		{
		}

        public async Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter)
        {
            return await _dbContext.JobRequirements.Include("JobCategory").Where(filter).ToListAsync();
        }

        
    }
}

