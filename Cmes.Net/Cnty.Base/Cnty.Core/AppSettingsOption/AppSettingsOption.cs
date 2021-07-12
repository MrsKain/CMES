using System;
using System.Collections.Generic;
using System.Text;

namespace Cnty.Core.AppSettingsOption
{
    public class AppSettingsOption
    {
        public IDictionary<string, string> Settings { get; set; }
        public IDictionary<string, string> ConnectionStrings { get; set; }
    }

    public class HostOption
    {
        public IDictionary<string, HostItemOption> Hosts { get; set; }
    }
    public class HostItemOption
    {
        public string Protocol { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
