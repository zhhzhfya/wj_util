using Redbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wj_util.events
{
    class ServerChangeEvent<List> : EventBase
    {
        public List<string> Servers { get; protected set; }
        public ServerChangeEvent(List<string> servers)
        {
            Servers = servers;
        }


    }
}
