using System;
using System.Collections.Generic;

namespace CACore.Trees
{
    public class NodeChangeEventArgs : EventArgs
    {
        public INode Node;
        public INode ParentNode;

        public NodeChangeEventArgs(INode node, INode parent)
        {
            Node = node;
            ParentNode = parent;
        }
    }

    public class NodesEventArgs : EventArgs
    {
        public List<INode> Nodes;
        public INode ParentNode;

        public NodesEventArgs(List<INode> nodes, INode parent)
        {
            Nodes = nodes;
            ParentNode = parent;
        }
    }
}