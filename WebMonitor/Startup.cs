using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebMonitor.Startup))]

namespace WebMonitor
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("All", "Monitor/{*all}", new {controller = "Monitor"});
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            app.UseWebApi(config);
            app.MapSignalR();
        }
    }
}
