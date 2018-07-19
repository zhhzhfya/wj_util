using Redbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wj_util.events
{
    class EventDelete<TreeNode> : EventBase
    {
        public TreeNode treeNode { get; protected set; }
        public EventDelete(TreeNode node)
        {
            this.treeNode = node;
        }
    }
}
