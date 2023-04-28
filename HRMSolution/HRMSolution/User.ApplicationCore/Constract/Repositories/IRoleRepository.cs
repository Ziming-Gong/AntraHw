using System.Linq.Expressions;
using User.ApplicationCore.Entity;

namespace User.ApplicationCore.Constract.Repositories;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role> FirstOrDefaultWithInclude(Expression<Func<Role, bool>> where,
        params Expression<Func<Role, object>>[] includes);
}