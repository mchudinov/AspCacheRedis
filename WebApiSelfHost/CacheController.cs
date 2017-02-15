using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebApiSelfHost
{
    [AutoInvalidateCacheOutput]
    [CacheOutput(ServerTimeSpan = 30)]
    public class CacheController : ApiController
    {
        // GET api/cache         
        public IEnumerable<string> Get()
        {
            Console.WriteLine("return from method");
            return new [] { "value1", "value2" };
        }

        [HttpPost]
        public void Post(string str)
        {
            //
        }
    }
}
