using System.Threading.Tasks;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Interfaces
{
    public interface ITableHelper
    {
        Task       ValidateTableExists(ITable table, string database);
        Task       CreateDatabase(string database);
        Task       DropDatabase(string database);
        Task<bool> DoesDatabaseExists(string databaseName);
        Task<bool> DoesTableExist(string tableName, string databaseName);
        void       Dispose();
        Task       AddConstrainst(ITableWithAdvancedConstraints table, string databaseName);
    }
}