using System.Linq.Expressions;
using User.ApplicationCore.Entity;
using User.ApplicationCore.Models;

namespace User.ApplicationCore.Constract.Repositories;

public interface IUserRoleRepository : IBaseRepository<UserRole>
{
    Task<UserRole> FirstOrDefaultWithInclude(Expression<Func<UserRole, bool>> where, params Expression<Func<UserRole, object>>[] includes);
    
    
}