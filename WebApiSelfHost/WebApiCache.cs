using System;
using System.Collections.Generic;
using WebApi.OutputCache.Core.Cache;

namespace WebApiSelfHost
{
    internal class WebApiCache : IApiOutputCache
    {
        private static readonly Cache.ICacheProvider CacheManagerCache = new Cache.CacheManagerCache();

        public void RemoveStartsWith(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key) where T : class
        {
            Console.WriteLine("cache");
            return CacheManagerCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return CacheManagerCache.Get<object>(key);
        }

        public void Remove(string key)
        {
            CacheManagerCache.Remove(key);
        }

        public bool Contains(string key)
        {
            return CacheManagerCache.Exists(key);
        }

        public void Add(string key, object o, DateTimeOffset expiration, string dependsOnKey = null)
        {
            CacheManagerCache.Set(key, o, expiration);
        }

        public IEnumerable<string> AllKeys { get
            {
                throw new NotImplementedException();
            }
        }
    }
}
