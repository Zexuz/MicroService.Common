using System.Data;
using System.Threading.Tasks;
using MicroService.Common.Core.Databases.Repository.MsSql.Impl;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Interfaces
{
    public interface ISqlRepositoryBase<TEntity> where TEntity : SqlEntityBase //
    {
        Task<TEntity> FindByIdAsync(int id);
        Task<TEntity> FindByIdAsync(int id, IDbTransaction transaction);
        Task<int>     InsertAsync(TEntity entity);
        Task<int>     InsertAsync(TEntity entity, IDbTransaction transaction);
        Task<bool>    RemoveAsync(TEntity entity);
        Task<bool>    RemoveAsync(TEntity entity, IDbTransaction transaction);
        Task<bool>    UpdateAsync(TEntity entity);
        Task<bool>    UpdateAsync(TEntity entity, IDbTransaction transaction);
    }
}