using System;
using Infrastructure.Data;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
	{
		public SubmissionRepository(RecruitingDbContext context) : base(context)
		{
		}

        public async Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where, params Expression<Func<Submission, object>>[] includes)
        {
            var query = _dbContext.Set<Submission>().AsQueryable();
            if(includes != null)
            {
                foreach(var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.FirstOrDefaultAsync(where);
        }
    }
}

