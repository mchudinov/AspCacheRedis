using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApiSelfHost
{
    public class CacheController : ApiController
    {
        // GET api/cache 
        public IEnumerable<string> Get()
        {
            Console.WriteLine("request method");
            return new [] { "value1", "value2" };
        }
    }
}
