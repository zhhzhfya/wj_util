using Newtonsoft.Json.Linq;
using Redbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wj_util.events
{
    class EventModify<TreeNode> : EventBase
    {
         public TreeNode treeNode { get; protected set; }

         public JObject config { get; protected set; }
         public EventModify(TreeNode node, JObject config)
        {
            this.treeNode = node;
            this.config = config;
        }
    }
}
