using BackendOne.API.Interfaces;
using BackendOne.DataAccess.Interfaces;
using BackendOne.DataAccess.Models;

namespace BackendOne.API.Services
{
    public class ProductService : IProduct
    {
        private IProductAccess _database;

        public ProductService(IProductAccess database)
        {
            _database = database;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                if (product == null) return false;
                product.Id = Guid.NewGuid();
                var result = await _database.AddProductAsync(product);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<Product>?> GetProductsAsync()
        {
            try
            {
                var products = await _database.GetProductsAsync();
                if (products == null) return null;

                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}

