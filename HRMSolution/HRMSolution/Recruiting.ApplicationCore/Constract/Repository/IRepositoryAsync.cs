namespace Recruiting.ApplicationCore.Constract.Repository;

public interface IRepositoryAsync<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> InsertAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<int> UpdateAsync(T entity);

}