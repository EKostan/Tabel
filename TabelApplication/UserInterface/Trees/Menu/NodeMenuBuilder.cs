using CACore.Trees;
using CACore.Trees.Actions;
using DevExpress.XtraBars;
using UserInterface.Ribbon;

namespace UserInterface.Trees.Menu
{
    class NodeMenuBuilder
    {
        public PopupMenu PopupMenu { get; set; }
        public INode Node { get; set; }

        public void Build()
        {
            if(PopupMenu == null || Node == null)
                return;

            foreach (var action in Node.Actions)
            {
                AddPopupMenuItem(action);
            }
        }

        void AddPopupMenuItem(IAction action)
        {
            // action.Node должен инициализировать тот кто создает action
            action.Node = Node;
            
            var buttonMenuItem = new ItemButtonAction(action);
            var barItem = BarItemCreatorFactory.CreateBarItem(buttonMenuItem);
            PopupMenu.AddItem(barItem);
        }

    }
}
