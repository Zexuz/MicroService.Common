using System;

namespace MicroService.Common.Core.Managers
{
    public class CacheResource<TEntity> : ICacheResource<TEntity>
    {
        public bool    IsValid => ((Created + LifeSpan) - DateTime.Now).TotalSeconds > 0;
        public TEntity Entity  { get; }

        private DateTime Created  { get; }
        private TimeSpan LifeSpan { get; }

        public CacheResource(TimeSpan lifeSpan, TEntity entity)
        {
            Created = DateTime.Now;
            LifeSpan = lifeSpan;
            Entity = entity;
        }
    }
}