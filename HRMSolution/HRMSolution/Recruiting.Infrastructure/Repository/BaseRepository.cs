using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Recruiting.Infrastructure.Repository;

public class BaseRepository<T> : IRepositoryAsync<T> where T:class
{
    private readonly RecruitingDbContext _context;
    public BaseRepository(RecruitingDbContext context)
    {
        this._context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<int> InsertAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        return _context.SaveChanges();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return 0;
        }

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return 1;



    }

    public async Task<int> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    
    
    
}