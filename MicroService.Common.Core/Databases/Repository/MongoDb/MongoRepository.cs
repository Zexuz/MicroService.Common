using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MicroService.Common.Core.Databases.Repository.MongoDb
{
    public class MongoRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoDbConnectionFacotry client)
        {
            _database = client.Database;
        }

        public async Task<TEntity> GetAsync(TIdentifier id)
        {
            return await _database.GetCollection<TEntity>(typeof(TEntity).Name).Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> GetAll()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name).Find(new BsonDocument()).ToListAsync();
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            var collection = _database.GetCollection<TEntity>(typeof(TEntity).Name);

            await collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions {IsUpsert = true});

            return entity;
        }

        public async Task Delete(TIdentifier id)
        {
            var collection = _database.GetCollection<TEntity>(typeof(TEntity).Name);

            await collection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public async Task Delete(TEntity entity)
        {
            var collection = _database.GetCollection<TEntity>(typeof(TEntity).Name);

            await collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }
    }
}