namespace Interview.ApplicationCore.Constracts.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<int> InsertAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();

    Task<int> UpdateAsync(T entity);

    Task<int> DeleteById(int id);

}