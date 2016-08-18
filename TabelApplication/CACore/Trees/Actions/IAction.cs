using System.Drawing;

namespace CACore.Trees.Actions
{
    public interface IAction
    {
        Icon Icon { get; set; }
        string Name { get; set; }
        INode Node { get; set; }
        void Execute();
    }

    public interface IAction<T> : IAction
        where T : INode
    {
        new T Node { get; set; }
    }
}
