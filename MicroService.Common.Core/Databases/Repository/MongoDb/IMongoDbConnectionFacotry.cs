using MongoDB.Driver;

namespace MicroService.Common.Core.Databases.Repository.MongoDb
{
    public interface IMongoDbConnectionFacotry
    {
        IMongoDatabase Database { get; }
    }
}