﻿using System.Configuration;

namespace AspCacheRedis
{
    public abstract class CacheProvider<TCache> : ICacheProvider
    {
        public int CacheDuration { get; set; }

        protected TCache Cache;

        private const int DefaultCacheDurationMinuts = 30;

        protected readonly string KeyPrefix;

        public CacheProvider()
        {
            int result;
            CacheDuration = int.TryParse(ConfigurationManager.AppSettings["CacheDefaultDurationMinutes"], out result) ? result : DefaultCacheDurationMinuts;
            KeyPrefix = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["CacheKeyPrefix"]) ? ConfigurationManager.AppSettings["CacheKeyPrefix"] : string.Empty;
            Cache = InitCache();
        }

        protected abstract TCache InitCache();

        public abstract T Get<T>(string key);

        public abstract void Set<T>(string key, T value);

        public abstract void SetSliding<T>(string key, T value);

        public abstract void Set<T>(string key, T value, int duration);

        public abstract void SetSliding<T>(string key, T value, int duration);

        public abstract void Remove(string key);
    }
}
