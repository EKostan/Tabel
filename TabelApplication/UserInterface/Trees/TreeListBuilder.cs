using System.Collections.Generic;
using CACore.Trees;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using InterfaceLibrary;

namespace UserInterface.Trees
{
    class TreeListBuilder
    {
        public TreeList TreeList { get; set; }
        public TreeListNode ParentTreeNode { get; set; }

        public ImageController ImageController { get; set; }

        private delegate void buildDelegate(Tree tree);

        public void Build(Tree tree)
        {
            if (TreeList == null)
                return;

            if (TreeList.InvokeRequired)
            {
                TreeList.Invoke(new buildDelegate(Build), tree);
                return;
            }

            TreeList.BeginUpdate();

            TreeList.ClearNodes();

            foreach (var node in tree.Root.Nodes)
            {
                var treeListNode = CreateTreeListNode(node, ParentTreeNode);
            }
            
            TreeList.EndUpdate();

        }

        public void AddNode(INode node, INode parentNode)
        {
            var parentTreeListNode = FindTreeListNode(parentNode);
            var treeListNode = CreateTreeListNode(node, parentTreeListNode);
            treeListNode.Expanded = node.Expanded;
            treeListNode.Checked = node.State;
        }

        public void AddNodes(List<INode> nodes, INode parentNode)
        {
            TreeList.BeginUpdate();
            var parentTreeListNode = FindTreeListNode(parentNode);

            foreach (var node in nodes)
            {
                var treeListNode = CreateTreeListNode(node, parentTreeListNode);
                treeListNode.Expanded = node.Expanded;
                treeListNode.Checked = node.State;
            }

            TreeList.EndUpdate();
        }

        public TreeListNode FindTreeListNode(INode node)
        {
            var treeListNode = TreeList.FindNodeByFieldValue("DisplayName", node);
            return treeListNode;
        }

        private TreeListNode CreateTreeListNode(INode node, TreeListNode parent)
        {
            //                                                  0,                1
            var newNode = TreeList.AppendNode(new object[] { node, node.Description }, parent);
            newNode.Checked = node.State;
            if(node.NodeStatus != null)
                newNode.SetValue(2, node.NodeStatus.Icon);
            //newNode.Expanded = node.Expanded;
            newNode.Tag = node;


            if (node.Icon != null)
            {
                var imageIndex = ImageController.Add(node.Icon, node.GetType());
                newNode.StateImageIndex = imageIndex;
            }

            if (node.HasChildren)
            {
                foreach (var childNode in node.Nodes)
                {
                    var newChildNode = CreateTreeListNode(childNode, newNode);
                    newNode.Nodes.Add(newChildNode);
                }
            }

            return newNode;
        }

        public void DeleteNode(INode node, INode parentNode)
        {
            var treeListNode = FindTreeListNode(node);
            TreeList.DeleteNode(treeListNode);
        }

        public void UpdateTree(Tree tree)
        {
            if (TreeList.InvokeRequired)
            {
                TreeList.Invoke(new buildDelegate(UpdateTree), tree);
                return;
            }

            foreach (var node in tree.Root.Nodes)
            {
                UpdateTreeListNode(node);
            }

        }

        private void UpdateTreeListNode(INode node)
        {
            var treeListNode = FindTreeListNode(node);

            treeListNode.Checked = node.State;
            //treeListNode.Expanded = node.Expanded;

            if (node.NodeStatus != null)
                treeListNode.SetValue(2, node.NodeStatus.Icon);

            treeListNode.SetValue(0, node);
            treeListNode.Tag = node;

            foreach (var childrenNode in node.Nodes)
            {
                UpdateTreeListNode(childrenNode);
            }


        }

    }
}
