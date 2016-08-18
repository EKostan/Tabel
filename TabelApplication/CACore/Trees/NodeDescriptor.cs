using System.Collections.Generic;

namespace CACore.Trees
{
    public abstract class NodeDescriptor<T> : INodeDescriptor<T>
        where T : class, INode
    {
        protected NodeDescriptor()
        {
            NodeDescriptors = new List<INodeDescriptor>();
        }

        public string NodeKey { get; set; }
        public string ParentNodeKey { get; set; }
        public List<INodeDescriptor> NodeDescriptors { get; set; }
        
        
        public bool HasChildren 
        {
            get { return NodeDescriptors.Count > 0; }
        }

        INode INodeDescriptor.CreateNode()
        {
            return CreateNode();
        }

        public T CreateNode()
        {
            var res = DoCreateNode();

            if (res != null)
                res.Key = NodeKey;
            return res;
        }

        protected abstract T DoCreateNode();

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}