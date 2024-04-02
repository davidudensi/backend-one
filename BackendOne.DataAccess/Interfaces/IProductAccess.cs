using BackendOne.DataAccess.Models;

namespace BackendOne.DataAccess.Interfaces;
public interface IProductAccess
{
    public Task<List<Product>> GetProductsAsync();
    public Task<bool> AddProductAsync(Product product);
}

