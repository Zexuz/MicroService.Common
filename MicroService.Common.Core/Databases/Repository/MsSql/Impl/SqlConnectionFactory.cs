using System.Data.SqlClient;
using MicroService.Common.Core.Databases.Repository.MsSql.Interfaces;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Impl
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }


        public SqlConnection GetNewOpenConnection()
        {
            var conn = new SqlConnection
            {
                ConnectionString = _connectionString
            };
            conn.Open();
            return conn;
        }
    }
}