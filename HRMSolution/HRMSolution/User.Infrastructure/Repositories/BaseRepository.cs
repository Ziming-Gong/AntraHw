using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Entity;
using User.ApplicationCore.Exceptions;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly UserDbContext _userDbContext;
    public BaseRepository(UserDbContext context)
    {
        _userDbContext = context;
    }

    public async Task<int> InsertAsync(T entity)
    {
        await _userDbContext.AddAsync(entity);
        return _userDbContext.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _userDbContext.Set<T>().ToListAsync();
    }

    public async Task<int> DeleteById(int id)
    {
        var cur = await _userDbContext.Set<Account>().FindAsync(id);
        if (cur == null)
        {
            throw new NotFoundException("Account", id);
        }
        _userDbContext.Remove(cur);
        return  _userDbContext.SaveChanges();
    }

    public async Task<T> GetById(int id)
    {
        return await _userDbContext.Set<T>().FindAsync(id);
    }

    public async Task<int> Update(T entity)
    { 
        _userDbContext.Update(entity);
        return _userDbContext.SaveChanges();
    }
}