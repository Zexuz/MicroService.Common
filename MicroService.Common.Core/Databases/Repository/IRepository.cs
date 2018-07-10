using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroService.Common.Core.Databases.Repository
{
    public interface IRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {
        Task<TEntity>       GetAsync(TIdentifier id);
        Task<List<TEntity>> GetAll();
        Task<TEntity>       SaveAsync(TEntity entity);
        Task                Delete(TIdentifier id);
        Task                Delete(TEntity entity);
    }
}