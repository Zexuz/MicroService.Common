using System;

namespace MicroService.Common.Core.Managers
{
    public interface ISimpleCacheResourceManager<TEntity> where TEntity : class
    {
        TimeSpan CacheTimeSpan { get; set; }
        void     AddToCache(string identifier, TEntity cahce);
        bool     HasCache(string identifier);
        TEntity  LookupCache(string identifier);
    }
}