﻿namespace AspCacheRedis.Cache
{
    public interface ICacheProvider
    {
        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached value. Default(T) if item doesn't exist.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Insert value into the cache using appropriate name/value pairs
        /// Use predefined cache duration with absolute expiration
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="value">Item to be cached</param>
        /// <param name="key">Name of item</param>
        void Set<T>(string key, T value);

        /// <summary>
        /// Insert value into the cache using appropriate name/value pairs
        /// Use predefined cache duration with sliding expiration
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="value">Item to be cached</param>
        /// <param name="key">Name of item</param>
        void SetSliding<T>(string key, T value);

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs WITH a cache duration set in minutes
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Item to be cached</param>
        /// <param name="value">Name of item</param>
        /// <param name="duration">Cache duration in minutes with absolute expiration</param>
        void Set<T>(string key, T value, int duration);

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs WITH a cache duration set in minutes
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Item to be cached</param>
        /// <param name="value">Name of item</param>
        /// <param name="duration">Cache duration in minutes with sliding expiration</param>
        void SetSliding<T>(string key, T value, int duration);

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>        
        void Remove(string key);
    }
}
