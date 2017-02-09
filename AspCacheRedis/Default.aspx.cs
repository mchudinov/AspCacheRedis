using System;
using AspCacheRedis.Cache;

namespace AspCacheRedis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cache = new HttpCache();
            cache.Set("key1","Hello!");
            str1.InnerText = cache.Get<string>("key1");

            var redis = new CacheManagerCache();
            redis.Set("key2","Hello2!");
            str2.InnerText = redis.Get<string>("key2");

            Session["cache"] = "cache in redis";
            str3.InnerText = Session["cache"].ToString();
        }
    }
}