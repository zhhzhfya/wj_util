using Redbus;
using Redbus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wj_util.events
{
    class EventBusHelper
    {
        static IEventBus eventBus = new EventBus();

        public static IEventBus getBus()
        {
            return eventBus;
        }
    }
}
