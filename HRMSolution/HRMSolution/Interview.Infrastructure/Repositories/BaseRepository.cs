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
        // return response;a
    }

    public async Task<int> InsertAsync(T entity)
    {
        await _context.AddAsync(entity);
        return _context.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var response = await _context.Set<T>().ToListAsync();
        return response;
    }

    public Task<int> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}