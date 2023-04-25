namespace User.ApplicationCore.Constract.Repositories;

public  interface IBaseRepository<T>
{
    Task<int> InsertAsync(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<int> DeleteById();
    Task<T> GetById(int id);
    Task<int> Update(T entity);

}