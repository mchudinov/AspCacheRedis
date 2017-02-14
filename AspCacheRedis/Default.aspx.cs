using System;
using System.Net;
using System.Net.Http;

namespace AspCacheRedis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cache.ICacheProvider cache = new Cache.HttpCache();
            cache.Set("key1","Hello!");
            str1.InnerHtml = cache.Get<string>("key1");

            Cache.ICacheProvider cacheManagerCache = new Cache.CacheManagerCache();
            cacheManagerCache.Set("key2","Hello2!");
            str2.InnerHtml = cacheManagerCache.Get<string>("key2");

            Session["cache"] = "Cache in Redis!";
            str3.InnerHtml = Session["cache"].ToString();

            var client = new WebClient();
            str4.InnerHtml = client.DownloadString("http://localhost:8080/api/Cache");
        }
    }
}