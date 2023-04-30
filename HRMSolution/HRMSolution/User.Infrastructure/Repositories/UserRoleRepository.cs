using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Entity;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repositories;

public class UserRoleRepository : BaseRepository<UserRole> , IUserRoleRepository
{
    private readonly UserDbContext _context;
    public UserRoleRepository(UserDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserRole> FirstOrDefaultWithInclude(Expression<Func<UserRole, bool>> where, params Expression<Func<UserRole, object>>[] includes)
    {
        var query = _context.Set<UserRole>().AsQueryable();
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.FirstOrDefaultAsync(where);
    }
}