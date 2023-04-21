using System;
using Infrastructure.Data;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
namespace Infrastructure.Repositories
{
	public class JobCategoryRepository : BaseRepository<JobCategory>, IJobCategoryRepository
	{
		public JobCategoryRepository(RecruitingDbContext context) : base(context)
		{

		}
	}
}

