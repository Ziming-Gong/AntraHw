using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Entity;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    private readonly UserDbContext _context;

    public AccountRepository(UserDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<Account> GetByEmail(string email)
    {
        return await _context.Set<Account>().Where(x => x.Email == email).FirstOrDefaultAsync();
    }

    public async Task<Account> FirstOrDefaultWithIncludes(Expression<Func<Account, bool>> where, params Expression<Func<Account, object>>[] includes)
    {
        var query = _context.Set<Account>().AsQueryable();
        if (includes != null)
        {
            foreach (var navi in includes)
            {
                query = query.Include(navi);

            } 
        }

        return await query.FirstOrDefaultAsync(where);

    }
}