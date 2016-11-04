using System;
using HashidsNet;
using Microsoft.AspNet.SignalR;

namespace WebMonitor
{
    public class MonitorHub : Hub
    {
        private static readonly Random _random = new Random();
        private static readonly Hashids _hashids = new Hashids(minHashLength: 6);

        public string Monitor(string channel)
        {
            if(string.IsNullOrEmpty(channel)) channel = CreateChannel();

            Groups.Add(Context.ConnectionId, channel);
            return channel;
        }

        private static string CreateChannel()
        {
            return _hashids.Encode(_random.Next());
        }
    }
}