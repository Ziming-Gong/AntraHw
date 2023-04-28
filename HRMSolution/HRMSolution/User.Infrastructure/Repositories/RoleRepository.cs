using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Entity;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    private readonly UserDbContext _context;
    public RoleRepository(UserDbContext context) : base(context)
    {
        _context = context;
    }

    //TODO error
    public async Task<Role> FirstOrDefaultWithInclude(Expression<Func<Role, bool>> where, params Expression<Func<Role, object>>[] includes)
    {
        var query = _context.Set<Role>().AsQueryable();
        if (includes != null)
        {
            foreach (var q in includes)
            {
                query = query.Include(q);
            }
        }

        return await query.FirstOrDefaultAsync(where);
    }
}