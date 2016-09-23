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
            config.Routes.MapHttpRoute("All", "{channel}/{*all}", new {controller = "Monitor"});
            app.MapSignalR();
            app.UseWebApi(config);
        }
    }
}
