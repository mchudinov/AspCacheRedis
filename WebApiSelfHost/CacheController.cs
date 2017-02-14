using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebApiSelfHost
{
    public class CacheController : ApiController
    {
        // GET api/cache 
        [CacheOutput(ServerTimeSpan = 10)]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("return from method");
            return new [] { "value1", "value2" };
        }
    }
}
