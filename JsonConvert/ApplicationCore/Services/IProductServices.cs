using ApplicationCore.Entity;

namespace ApplicationCore.Services;

public interface IProductServices
{
    Task<List<Product>> GetAllProduct();

    Task<List<Product>> GetByCategory(string category);
    // Task<Product> Get
}