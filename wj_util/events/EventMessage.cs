using Redbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wj_util.events
{
    class EventMessage<List> : EventBase
    {
        public List<string> messages { get; protected set; }
        public EventMessage(List<string> messages)
        {
            this.messages = messages;
        }
    }
}
