using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repositories
{
	public interface IJobRequirementRepository : IBaseRepository<JobRequirement>
	{
        public Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter);
    }
}

