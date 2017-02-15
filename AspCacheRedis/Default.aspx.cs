using System;

namespace AspCacheRedis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cache.ICacheProvider cache = new Cache.HttpCache();
            cache.Set("key1", "Hello from System.Web.Caching.Cache");
            str1.InnerHtml = cache.Get<string>("key1");

            Cache.ICacheProvider cacheManagerCache = new Cache.CacheManagerCache();
            cacheManagerCache.Set("key2", "Hello from Redis through CacheManagerCache!");
            str2.InnerHtml = cacheManagerCache.Get<string>("key2");

            cacheManagerCache.Set("key3", new Widget());

            Session["cache"] = "Session is in Redis!";
            str3.InnerHtml = Session["cache"].ToString();

            Session["widget"] = new Widget {Number = 99, Name = "Test99"};
            str4.InnerHtml = "Non serilazable item is in session " + ((Widget) Session["widget"]).Name;
        }
    }

    internal class Widget
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}