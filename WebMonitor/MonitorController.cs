using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace WebMonitor
{
    public class MonitorController : ApiController
    {
        private readonly IHubContext<IMonitorClient> _monitor = GlobalHost.ConnectionManager.GetHubContext<MonitorHub, IMonitorClient>();

        [HttpPost, HttpGet, HttpPut, HttpDelete]
        public async Task<IHttpActionResult> All(string connectionId)
        {
            var content = await Request.Content.ReadAsStringAsync();
            _monitor.Clients.Client(connectionId).AddRequest(new Request(Request.ToString(), content));
            return Ok();
        }
    }
}
