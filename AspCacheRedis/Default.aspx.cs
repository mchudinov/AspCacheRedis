using System;

namespace AspCacheRedis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cache = new HttpCache();
            cache.Set("key1","Hello!");
            str1.InnerHtml = cache.Get<string>("key1");

            var redis = new CacheManagerCache();
            redis.Set("key2","Hello2!");
            str2.InnerHtml = redis.Get<string>("key2");

            Session["cache"] = "Cahe in Redis!";
            str3.InnerHtml = Session["cache"].ToString();
        }
    }
}