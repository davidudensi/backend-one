using BackendOne.DataAccess.Interfaces;
using BackendOne.DataAccess.Models;
using MongoDB.Driver;

namespace BackendOne.DataAccess.Access
{
    public class ProductAccess : IProductAccess
    {
        private readonly IDatabase _database;
        public ProductAccess(IDatabase database)
        {
            _database = database;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            if (product == null) return false;
            var collection = _database.ConnectToMongo<Product>("product");
            await collection.InsertOneAsync(product);
            return true;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var collection = _database.ConnectToMongo<Product>("product");
            var result = await collection.FindAsync(Builders<Product>.Filter.Empty);
            return result.ToList();
        }
    }
}

