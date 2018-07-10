using System;
using System.Data.SqlClient;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Interfaces
{
    public interface ITransactionWrapper : IDisposable
    {
        void           Commit();
        void           Rollback();
        SqlTransaction Transaction   { get; }
        SqlConnection  SqlConnection { get; }
    }
}