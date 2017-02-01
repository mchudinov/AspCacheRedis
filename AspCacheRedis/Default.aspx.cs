using System;

namespace AspCacheRedis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cache = new HttpCache();
            cache.Set("key1","Hello!");
            string str = cache.Get<string>("key1");

            var redis = new CacheManagerCache();
            redis.Set("key2","Hello2!");
            string str2 = redis.Get<string>("key2");
        }
    }
}