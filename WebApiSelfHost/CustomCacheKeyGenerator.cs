using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web.Http.Controllers;

namespace WebApiSelfHost
{
    public class CustomCacheKeyGenerator : WebApi.OutputCache.V2.DefaultCacheKeyGenerator
    {
        public override string MakeCacheKey(HttpActionContext actionContext, MediaTypeHeaderValue header, bool excludeQueryString=false)
        {
            //var temp = base.MakeCacheKey(actionContext, header, excludeQueryString);
            //temp = Regex.Replace(temp, header.CharSet, string.Empty);
            //temp = Regex.Replace(temp, header.MediaType, string.Empty);
            //temp = Regex.Replace(temp, @"\\", string.Empty);
            //temp = Regex.Replace(temp, @"/", string.Empty);
            //temp = Regex.Replace(temp, @";", string.Empty);
            //temp = Regex.Replace(temp, @":", string.Empty);
            //temp = Regex.Replace(temp, @"=", string.Empty);
            //temp = Regex.Replace(temp, "charset", string.Empty);
            //temp = Regex.Replace(temp, @"\s+", string.Empty);

            string queryPairs = string.Empty;                 
            foreach (var item in actionContext.Request.GetQueryNameValuePairs())
            {
                queryPairs += item.Key + "=" + item.Value;
            }
            string temp = actionContext.Request.RequestUri.LocalPath + "-" + actionContext.Request.Method + "-" + queryPairs;
            temp = Regex.Replace(temp, @"/", "-");

            return temp;
        }
    }
}
