using System.Drawing;

namespace CACore.Trees.Actions
{
    public abstract class DataAction<T> : IAction<T>
        where T : INode
    {
        protected DataAction(T node)
        {
            Node = node;
        }

        public Icon Icon { get; set; }
        public string Name { get; set; }
        public T Node { get; set; }

        INode IAction.Node
        {
            get { return Node; }
            set { Node = (T)value; }
        }

        public void Execute()
        {
            DoExecute();
        }

        protected abstract void DoExecute();
    }
}