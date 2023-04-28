using System.Linq.Expressions;
using User.ApplicationCore.Entity;

namespace User.ApplicationCore.Constract.Repositories;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<Account> GetByEmail(string email);
    Task<Account> FirstOrDefaultWithIncludes(Expression<Func<Account, bool>> where, params Expression<Func<Account, object>>[] includes);
}