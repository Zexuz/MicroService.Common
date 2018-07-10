namespace MicroService.Common.Core.Managers
{
    public interface ICacheResource<TEntity>
    {
        bool    IsValid { get; }
        TEntity Entity  { get; }
    }
}