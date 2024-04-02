using BackendOne.DataAccess.Models;

namespace BackendOne.API.Interfaces
{
    public interface IProduct
    {
        public Task<List<Product>?> GetProductsAsync();
        public Task<bool> AddProductAsync(Product product);
    }
}
