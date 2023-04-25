using System.Linq.Expressions;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Constract.Repository;

public interface ICandidateRepositoryAsync : IRepositoryAsync<Candidate>
{
    Task<Candidate> GetUserByEmailAsync(string email);

    Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where,
        params Expression<Func<Candidate, object>>[] includes);
    
}