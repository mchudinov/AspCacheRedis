using System.Web.Http;
using Owin;
using WebApi.OutputCache.V2;

namespace WebApiSelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var cache = new WebApiCache();
            config.CacheOutputConfiguration().RegisterCacheOutputProvider(() => cache);

            app.UseWebApi(config);
        }
    }
}