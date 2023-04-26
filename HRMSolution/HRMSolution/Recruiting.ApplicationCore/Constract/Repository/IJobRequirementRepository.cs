using System.Linq.Expressions;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.ApplicationCore.Constract.Repository;

public interface IJobRequirementRepository : IRepositoryAsync<JobRequirement>
{
    Task<IEnumerable<JobRequirement>> GetJobRequirementIncludeCategory(Expression<Func<JobRequirement, bool>> filter);

}