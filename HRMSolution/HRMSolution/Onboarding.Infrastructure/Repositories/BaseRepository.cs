using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly OnboardingDbContext _context;

    public BaseRepository(OnboardingDbContext context)
    {
        _context = context;
    }
    public async Task<int> Insert(T entity)
    {
        _context.Set<T>().Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var response = await _context.Set<T>().ToListAsync();
        return response;
    }

    public async Task<int> DeleteById(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        { 
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<int> Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return 1;
    }
}