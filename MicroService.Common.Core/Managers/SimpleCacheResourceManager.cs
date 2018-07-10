using System;
using System.Collections.Generic;

namespace MicroService.Common.Core.Managers
{
    public class SimpleCacheResourceManager<TEntity> : ISimpleCacheResourceManager<TEntity> where TEntity : class
    {
        private Dictionary<string, CacheResource<TEntity>> _entityCaches;

        public TimeSpan CacheTimeSpan { get; set; }

        public SimpleCacheResourceManager()
        {
            _entityCaches = new Dictionary<string, CacheResource<TEntity>>();
        }

        public void AddToCache(string identifier, TEntity cahce)
        {
            RemoveOutdatedCahches();
            try
            {
                _entityCaches.Add(identifier, new CacheResource<TEntity>(CacheTimeSpan, cahce));
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public bool HasCache(string identifier)
        {
            RemoveOutdatedCahches();
            var hasCache = _entityCaches.ContainsKey(identifier);
            return hasCache;
        }

        public TEntity LookupCache(string identifier)
        {
            RemoveOutdatedCahches();
            try
            {
                var cache = _entityCaches[identifier].Entity;
                return cache;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void RemoveOutdatedCahches()
        {
            var identifiersToRemove = new List<string>();
            foreach (var cache in _entityCaches)
            {
                if (cache.Value.IsValid) continue;
                identifiersToRemove.Add(cache.Key);
            }

            foreach (var id in identifiersToRemove)
            {
                _entityCaches.Remove(id);
            }
        }
    }
}