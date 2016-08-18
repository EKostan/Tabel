using System.Drawing;

namespace CACore.Trees.Actions
{
    public class DeleteNodeAction : IAction
    {
        public DeleteNodeAction(INode node)
        {
            Name = "Удалить";
            Node = node;
        }

        public Icon Icon { get; set; }
        public string Name { get; set; }
        public INode Node { get; set; }

        public void Execute()
        {
            if (Node == null || Node.Tree == null)
            {
                return;
            }

            Node.Tree.RemoveNode(Node);
        }
    }
}