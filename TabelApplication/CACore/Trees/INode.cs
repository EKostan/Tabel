using System.Collections.Generic;
using System.Drawing;
using CACore.Trees.Actions;

namespace CACore.Trees
{
    public interface INode
    {
        string DisplayName { get; set; }
        string Description { get; set; }

        string Key { get; set; }
        Icon Icon { get; set; }
        
        INode Parent { get; set; }
        bool Visible { get; set; }
        ICollection<INode> Nodes { get; set; }
        bool HasChildren { get; }
        Tree Tree { get; set; }
        bool Checked { get; set; }

        bool State { get; set; }


        bool Expanded { get; set; }

        ICollection<IAction> Actions { get; set; }

        INodeStatus NodeStatus { get; set; }
    }
}
