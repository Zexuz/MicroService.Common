namespace MicroService.Common.Core.Databases.Repository.MsSql.Interfaces
{
    public interface ITable
    {
        string TableName    { get; }
        string TableContent { get; }
    }

    public interface ITableWithAdvancedConstraints : ITable
    {
        string Constraints { get; }
    }
}