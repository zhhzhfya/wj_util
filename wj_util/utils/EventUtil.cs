using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wj_util.events;

namespace wj_util.utils
{
    class EventUtil
    {
        public static void send(string msg)
        {
            // 提示信息
            List<String> l = new List<String>();
            l.Add(msg);
            EventBusHelper.getBus().Publish(new EventMessage<List<String>>(l));
        }
    }
}
