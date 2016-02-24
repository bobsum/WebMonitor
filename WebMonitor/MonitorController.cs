using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace WebMonitor
{
    public class MonitorController : ApiController
    {
        private readonly IHubContext<IMonitorClient> _monitor = GlobalHost.ConnectionManager.GetHubContext<MonitorHub, IMonitorClient>();

        [HttpPost, HttpGet, HttpPut, HttpDelete]
        public async Task<IHttpActionResult> All()
        {
            var content = await Request.Content.ReadAsStringAsync();
            var formattableString = $"{DateTime.Now}\r\n{Request}\r\n\r\n<em>{content}</em>";
            _monitor.Clients.All.AddRequest(formattableString);

            return Ok();
        }
    }
}
