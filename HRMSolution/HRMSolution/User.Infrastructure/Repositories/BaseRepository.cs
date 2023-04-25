using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Constract.Repositories;
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
        _userDbContext.Remove(id);
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