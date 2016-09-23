using System;
using Microsoft.AspNet.SignalR;

namespace WebMonitor
{
    public class MonitorHub : Hub
    {
        public string Monitor(string channel)
        {
            if(string.IsNullOrEmpty(channel)) channel = Guid.NewGuid().ToString("N");

            Groups.Add(Context.ConnectionId, channel);
            return channel;
        }
    }
}