using MongoDB.Driver;

namespace BackendOne.DataAccess.Interfaces
{
    public interface IDatabase
    {
        public IMongoCollection<T> ConnectToMongo<T>(in string collection);
    }
}

