using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using MicroService.Common.Core.Databases.Repository.MsSql.Interfaces;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Impl
{
    public class TableHelper : IDisposable, ITableHelper
    {
        private SqlConnection _connection;

        public TableHelper(ISqlConnectionFactory connectionForMaster)
        {
            _connection = connectionForMaster.GetNewOpenConnection();
        }

        public async Task ValidateTableExists(ITable table, string database)
        {
            if (!await DoesDatabaseExists(database))
                await CreateDatabase(database);

            if (await DoesTableExist(table.TableName, database)) return;

            var query = $"CREATE TABLE {database}.dbo.[{table.TableName}] {string.Format(table.TableContent, database)}";
            await _connection.ExecuteAsync(query);
        }

        public async Task CreateDatabase(string database)
        {
            await _connection.ExecuteScalarAsync($"CREATE DATABASE [{database}]");
        }

        public async Task DropDatabase(string database)
        {
            _connection.ChangeDatabase("MASTER");
            await _connection.ExecuteScalarAsync($"DROP DATABASE [{database}]");
        }

        public async Task<bool> DoesDatabaseExists(string databaseName)
        {
            var res = await _connection.ExecuteScalarAsync($"SELECT db_id('{databaseName}')");
            return res != null;
        }

        public async Task<bool> DoesTableExist(string tableName, string databaseName)
        {
            var query = $"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = '{tableName}'";
            _connection.ChangeDatabase(databaseName);
            var res = await _connection.ExecuteScalarAsync(query);
            _connection.ChangeDatabase("MASTER");
            return res != null;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public async Task AddConstrainst(ITableWithAdvancedConstraints table, string databaseName)
        {
            var query = string.Format(table.Constraints, databaseName);
            await _connection.ExecuteAsync(query);
        }
    }
}