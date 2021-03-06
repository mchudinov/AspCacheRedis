﻿using System;
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


            var task = DoWork(); //;

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
            HttpClient client = new HttpClient();
            string urlContents = await client.GetStringAsync("http://ya.ru");          
            return urlContents.Length;
        }

        private static Task<int> DoWork()
        {
            return Task.Run<int>(() => 999);
        }
    }

    internal class Widget
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}