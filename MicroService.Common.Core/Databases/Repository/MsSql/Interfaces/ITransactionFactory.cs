namespace MicroService.Common.Core.Databases.Repository.MsSql.Interfaces
{
    public interface ITransactionFactory
    {
        ITransactionWrapper BeginTransaction(System.Data.IsolationLevel level);
        ITransactionWrapper BeginTransaction();
    }
}