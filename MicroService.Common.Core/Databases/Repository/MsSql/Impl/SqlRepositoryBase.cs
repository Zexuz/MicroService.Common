using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MicroService.Common.Core.Databases.Repository.MsSql.Interfaces;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Impl
{
    public abstract class SqlRepositoryBase<TEntity> : ISqlRepositoryBase<TEntity> where TEntity : SqlEntityBase
    {
        protected ISqlConnectionFactory ConnectionFactory { get; }

        protected SqlRepositoryBase(ISqlConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public async Task<TEntity> FindByIdAsync(int id, IDbTransaction transaction)
        {
            return await transaction.Connection.GetAsync<TEntity>(id, transaction);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            using (var cn = ConnectionFactory.GetNewOpenConnection())
            {
                return await cn.GetAsync<TEntity>(id);
            }
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            using (var cn = ConnectionFactory.GetNewOpenConnection())
            {
                return await cn.InsertAsync(entity);
            }
        }

        public async Task<int> InsertAsync(TEntity entity, IDbTransaction transaction)
        {
            return await transaction.Connection.InsertAsync(entity, transaction);
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            using (var cn = ConnectionFactory.GetNewOpenConnection())
            {
                return await cn.DeleteAsync(entity);
            }
        }

        public async Task<bool> RemoveAsync(TEntity entity, IDbTransaction transaction)
        {
            return await transaction.Connection.DeleteAsync(entity, transaction);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var cn = ConnectionFactory.GetNewOpenConnection())
            {
                return await cn.UpdateAsync(entity);
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity, IDbTransaction transaction)
        {
            return await transaction.Connection.UpdateAsync(entity, transaction);
        }
    }
}