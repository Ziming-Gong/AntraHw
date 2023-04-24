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
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<int> InsertAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        return _context.SaveChanges();
    }
}