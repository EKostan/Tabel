using System;

namespace CACore.Trees
{
    public interface INodeDescriptor : ICloneable
    {
        string NodeKey { get; set; }
        string ParentNodeKey { get; set; }
        INode CreateNode();
    }

    public interface INodeDescriptor<T> : INodeDescriptor
        where T : class, INode
    {
        new T CreateNode();
    }
}