using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspCacheRedis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cache.ICache cacheManagerCache = new Cache.CacheManagerProvider();


            var temp = AccessTheWebAsync(); //;

            if (temp.GetType().IsGenericType)
            {
                var tt = temp.ConfigureAwait(false);
                Debug.Print("generic!");                
                //var t = tt.GetAwaiter().GetResult();
                var ttt = temp.Result;
                //Debug.Print(t.ToString());
            }


            cacheManagerCache.Set("key1", "Hello from Redis through CacheManagerProvider!");
            str2.InnerHtml = cacheManagerCache.Get<string>("key1");

            cacheManagerCache.Set("key2", new Widget());

            cacheManagerCache.Set("hashset", new HashSet<string>());
            var hashset = cacheManagerCache.Get<HashSet<string>>("hashset");
            hashset?.Add("Added value");
            cacheManagerCache.Set("hashset", hashset);

            Session["cache"] = "Session is in Redis!";
            str3.InnerHtml = Session["cache"].ToString();

            Session["widget"] = new Widget {Number = 99, Name = "Test99"};
            str4.InnerHtml = "Non serilazable item is in session " + ((Widget) Session["widget"]).Name;
        }


        private static async Task<int> AccessTheWebAsync()
        {
            // You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();

            // GetStringAsync returns a Task<string>. That means that when you await the
            // task you'll get a string (urlContents).
            //Task<string> getStringTask = client.GetStringAsync("http://ya.ru");

            string urlContents = await client.GetStringAsync("http://ya.ru");
            
            // The return statement specifies an integer result.
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value.
            return urlContents.Length;
        }


        private static async Task<int> DoWork()
        {
            var function = new Func<int>(() => GetSum(4, 5));
            var res = await Task.Run<int>(function);
            return res;
        }

        private static int GetSum(int a, int b)
        {
            return a + b;
        }
    }

    internal class Widget
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}