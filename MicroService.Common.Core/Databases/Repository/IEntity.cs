namespace MicroService.Common.Core.Databases.Repository
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; set; }
    }
}