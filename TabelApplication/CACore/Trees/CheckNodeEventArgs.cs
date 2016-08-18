using System;

namespace CACore.Trees
{
    public class CheckNodeEventArgs : EventArgs
    {
        public INode Node;
        public bool Check;
        public CheckNodeEventArgs(INode node, bool check)
        {
            Node = node;
            Check = check;
        }
    }
}