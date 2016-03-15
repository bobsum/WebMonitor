using System;
using System.Globalization;

namespace WebMonitor
{
    public class Request
    {
        public Request(string info, string content)
        {
            Info = info;
            Content = content;
        }

        public string Time { get; } = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        public string Info { get; private set; }
        public string Content { get; private set; }
    }
}