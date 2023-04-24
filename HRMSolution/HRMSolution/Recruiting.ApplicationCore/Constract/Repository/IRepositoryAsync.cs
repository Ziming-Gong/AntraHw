namespace Recruiting.ApplicationCore.Constract.Repository;

public interface IRepositoryAsync<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<int> InsertAsync(T entity);

}