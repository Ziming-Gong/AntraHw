namespace Onboarding.ApplicationCore.Constracts.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<int> Insert(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<int> DeleteById(int id);
    Task<T> GetById(int id);
    Task<int> Update(T entity);
}