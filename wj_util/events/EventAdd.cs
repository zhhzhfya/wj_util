using Redbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wj_util.events
{
    class EventAdd<TreeNode> : EventBase
    {
        public TreeNode treeNode { get; protected set; }
        public String text { get; protected set; }
        public EventAdd (TreeNode node, String text)
        {
            this.treeNode = node;
            this.text = text;
        }
    }
}