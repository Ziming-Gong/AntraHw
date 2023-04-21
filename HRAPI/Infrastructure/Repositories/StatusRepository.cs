using System;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;

namespace Infrastructure.Repositories
{
	public class StatusRepository : BaseRepository<Status>, IStatusRepository
	{
		public StatusRepository(RecruitingDbContext context) : base(context)
		{

		}

        public async Task<IEnumerable<Status>> GetStatusByState(string state)
        {
            return await _dbContext.Statuses.Where(x => x.State == state).Include(s => s.Submission).ToListAsync();
        }
    }
}

