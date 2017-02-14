using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AspCacheRedis
{
    public partial class Default : System.Web.UI.Page
    {
        static readonly HttpClient Client = new HttpClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var cache = new HttpCache();
            cache.Set("key1","Hello!");
            str1.InnerHtml = cache.Get<string>("key1");

            var redis = new CacheManagerCache();
            redis.Set("key2","Hello2!");
            str2.InnerHtml = redis.Get<string>("key2");

            Session["cache"] = "Cache in Redis!";
            str3.InnerHtml = Session["cache"].ToString();

            var client = new WebClient();
            str4.InnerHtml = client.DownloadString("http://localhost:8080/api/Cache");
        }
    }
}