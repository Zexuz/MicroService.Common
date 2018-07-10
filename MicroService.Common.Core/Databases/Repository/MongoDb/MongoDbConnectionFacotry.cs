using MongoDB.Driver;

namespace MicroService.Common.Core.Databases.Repository.MongoDb
{
    public class MongoDbConnectionFacotry : IMongoDbConnectionFacotry
    {
        public IMongoDatabase Database { get; private set; }

        public MongoDbConnectionFacotry(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(databaseName);
        }
    }
}