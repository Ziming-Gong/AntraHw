using Interview.ApplicationCore.Constracts.Repositories;
using Interview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Interview.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly InterviewDbContext _context;
    public BaseRepository(InterviewDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<int> InsertAsync(T entity)
    {
        _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var res = await _context.Set<T>().ToListAsync();
        return res;
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteById(int id)
    {
        var exist = await _context.Set<T>().FindAsync(id);
        if (exist != null)
        {
            _context.Remove(exist);
            return await _context.SaveChangesAsync();
        }
        else
        {
            return 0;
        }

    }
}