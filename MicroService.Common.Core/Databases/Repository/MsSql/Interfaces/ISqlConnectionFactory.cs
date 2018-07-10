using System.Data.SqlClient;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Interfaces
{
    public interface ISqlConnectionFactory
    {
        SqlConnection GetNewOpenConnection();
    }
}