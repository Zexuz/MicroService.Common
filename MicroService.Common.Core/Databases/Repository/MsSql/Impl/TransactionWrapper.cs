using System.Data;
using System.Data.SqlClient;
using MicroService.Common.Core.Databases.Repository.MsSql.Interfaces;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Impl
{
    public class TransactionWrapper : ITransactionWrapper
    {
        public SqlTransaction Transaction   { get; }
        public SqlConnection  SqlConnection { get; }

        public TransactionWrapper(SqlConnection sqlConnection, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            SqlConnection = sqlConnection;
            Transaction = sqlConnection.BeginTransaction(level);
        }

        public void Dispose()
        {
            SqlConnection.Close();
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }
    }
}