using System;
using CacheManager.Core;

namespace AspCacheRedis
{
    public class CacheManagerCache : CacheProvider<ICacheManager<object>>
    {    
        protected override ICacheManager<object> InitCache()
        {
            var cache = CacheFactory.FromConfiguration<object>("Redis");
            return cache;
        }

        public override T Get<T>(string key)
        {
            return Cache.Get<T>(KeyPrefix+key);
        }

        public override void Set<T>(string key, T value) 
        {
            Cache.Add(KeyPrefix+key, value);
            Cache.Expire(KeyPrefix+key, DateTime.Now.AddMinutes(CacheDuration));
        }

        public override void SetSliding<T>(string key, T value)
        {
            Cache.Add(KeyPrefix+key, value);
            Cache.Expire(KeyPrefix+key, new TimeSpan(0, CacheDuration, 0));
        }

        public override void Set<T>(string key, T value, int duration)
        {
            Cache.Add(KeyPrefix+key, value);
            Cache.Expire(KeyPrefix+key, DateTime.Now.AddMinutes(duration));
        }

        public override void SetSliding<T>(string key, T value, int duration)
        {
            Cache.Add(KeyPrefix+key, value);
            Cache.Expire(KeyPrefix+key, new TimeSpan(0, duration, 0));
        }

        public override void Remove(string key)
        {
            Cache.Remove(KeyPrefix+key);
        }        
    }
}
