using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace WebMonitor
{
    public class MonitorController : ApiController
    {
        private readonly IHubContext<IMonitorClient> _monitor = GlobalHost.ConnectionManager.GetHubContext<MonitorHub, IMonitorClient>();

        [HttpPost, HttpGet, HttpPut, HttpDelete, HttpPatch, HttpOptions, HttpHead]
        public async Task<IHttpActionResult> All(string channel)
        {
            var content = await Request.Content.ReadAsStringAsync();
            _monitor.Clients.Group(channel).AddRequest(new Request(Request.ToString(), content));
            return Ok(new { Success = true });
        }
    }
}
