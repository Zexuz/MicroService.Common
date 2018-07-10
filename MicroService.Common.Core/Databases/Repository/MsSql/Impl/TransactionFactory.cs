using MicroService.Common.Core.Databases.Repository.MsSql.Interfaces;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Impl
{
    public class TransactionFactory : ITransactionFactory
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public TransactionFactory(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public ITransactionWrapper BeginTransaction(System.Data.IsolationLevel level)
        {
            return new TransactionWrapper(_connectionFactory.GetNewOpenConnection(), level);
        }

        public ITransactionWrapper BeginTransaction()
        {
            return new TransactionWrapper(_connectionFactory.GetNewOpenConnection());
        }
    }
}