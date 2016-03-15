using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace WebMonitor
{
    public class MonitorHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}