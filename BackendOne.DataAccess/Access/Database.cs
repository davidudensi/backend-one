using BackendOne.DataAccess.Config;
using BackendOne.DataAccess.Interfaces;
using MongoDB.Driver;

namespace BackendOne.DataAccess.Access
{
    public class Database : IDatabase
    {
        private readonly DbOptions _options;
        public Database(DbOptions options)
        {
            _options = options;
        }

        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            Console.WriteLine($"Connecting to: {_options.Connection}");
            var client = new MongoClient(_options.Connection);
            var database = client.GetDatabase(_options.Database);
            return database.GetCollection<T>(collection);
        }
    }
}

