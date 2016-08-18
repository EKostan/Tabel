using Core;
using System;
using System.Collections.Generic;

namespace CACore.Trees
{
    public class Tree
    {
        public Tree()
        {
            Root = new RootNode();
        }

        public string Name { get; set; }

        private INode _root;
        public INode Root
        {
            get { return _root; }
            set
            {
                _root = value;
                _root.Tree = this;
            }
        }

        private bool _generateEvents = true;
        public void BeginUpdate()
        {
            _generateEvents = false;
        }

        public void EndUpdate()
        {
            _generateEvents = true;
        }


        public INode GetFirstNode(string key)
        {
            foreach (var node in Root.Nodes)
            {
                var res = GetFirstNode(key, node);

                if (res != null)
                    return res;
            }

            return null;
        }

       

        public ICollection<INode> GetNodes(INode rootNode)
        {
            var res = new List<INode>();
            res.Add(rootNode);

            if (!rootNode.HasChildren)
                return res;

            foreach (var node in rootNode.Nodes)
            {
                res.AddRange(GetNodes(node));
            }

            return res;
        }


        public INode GetFirstNode(string key, INode currentNode)
        {
            if (currentNode == null || currentNode.Key.Equals(key))
            {
                return currentNode;
            }

            if (!currentNode.HasChildren)
                return null;

            foreach (var node in currentNode.Nodes)
            {
                var res = GetFirstNode(key, node);

                if (res != null)
                    return res;
            }

            return null;
        }

        public virtual void AddNode(INode node, INode parentNode)
        {
            // если родительский узел не задан, 
            // то добавляем узел node в корень дерева
            if (parentNode == null)
            {
                AddNodeToRoot(node);
                return;
            }

            node.Tree = this;
            node.Parent = parentNode;
            parentNode.Nodes.Add(node);
            OnNodeAdded(new NodesEventArgs(new List<INode>() {node}, parentNode));
        }

        public virtual void AddNodes(List<INode> nodes, INode parentNode)
        {
            if (parentNode == null)
            {
                AddNodesToRoot(nodes);
                return;
            }

            foreach (var node in nodes)
            {
                node.Tree = this;
                node.Parent = parentNode;
                parentNode.Nodes.Add(node);
            }

            OnNodeAdded(new NodesEventArgs(nodes, parentNode));
        }

        

        public virtual void UpdateNode(INode node)
        {
            OnNodeUpdated(new BaseEventArgs<INode>(node));
        }

        public virtual void UpdateNodes()
        {
            OnNodeUpdated(new BaseEventArgs<INode>(Root));
        }

        public void RemoveNode(INode node)
        {
            var parentNode = node.Parent;
            node.Tree = null;
            
            if (node.Parent != null)
            {
                node.Parent.Nodes.Remove(node);
                node.Parent = null;
            }

            OnNodeDeleted(new NodeChangeEventArgs(node, parentNode));
        }

        void AddNodeToRoot(INode node)
        {
            node.Tree = this;
            Root.Nodes.Add(node);
            OnNodeAdded(new NodesEventArgs(new List<INode>() {node}, Root));
        }

        private void AddNodesToRoot(List<INode> nodes)
        {
            foreach (var node in nodes)
            {
                node.Tree = this;
                Root.Nodes.Add(node);
            }

            OnNodeAdded(new NodesEventArgs(nodes, Root));
        }

        public void CheckNode(INode node, bool check)
        {
            node.Checked = check;
            OnNodeChecked(new CheckNodeEventArgs(node, check));
        }


        public void CheckNodes(bool check)
        {
            CheckNodes(check, Root);
        }

        void CheckNodes(bool check, INode node)
        {
            if (node.Checked != check)
            {
                node.Checked = check;
                OnNodeChecked(new CheckNodeEventArgs(node, check));
            }

            if(!node.HasChildren)
                return;

            foreach (var itemNode in node.Nodes)
            {
                CheckNodes(check, itemNode);
            }
        }


        public void CheckStateNode(INode node, bool check)
        {
            node.State = check;
        }
        public void CheckStateNodes(bool check)
        {
            CheckStateNodes(check, Root);
        }

        void CheckStateNodes(bool check, INode node)
        {
            if (node.Checked != check)
            {
                node.State = check;
            }

            if (!node.HasChildren)
                return;

            foreach (var itemNode in node.Nodes)
            {
                CheckStateNodes(check, itemNode);
            }
        }

        public event EventHandler<NodesEventArgs> NodeAdded;
        public event EventHandler<BaseEventArgs<INode>> NodeUpdated;
        public event EventHandler<NodeChangeEventArgs> NodeDeleted;
        public event EventHandler<CheckNodeEventArgs> NodeChecked;

        protected virtual void OnNodeChecked(CheckNodeEventArgs e)
        {
            if(!_generateEvents)
                return;

            EventHandler<CheckNodeEventArgs> handler = NodeChecked;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnNodeAdded(NodesEventArgs e)
        {
            if (!_generateEvents)
                return;

            EventHandler<NodesEventArgs> handler = NodeAdded;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnNodeUpdated(BaseEventArgs<INode> e)
        {
            if (!_generateEvents)
                return;

            EventHandler<BaseEventArgs<INode>> handler = NodeUpdated;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnNodeDeleted(NodeChangeEventArgs e)
        {
            if (!_generateEvents)
                return;

            EventHandler<NodeChangeEventArgs> handler = NodeDeleted;
            if (handler != null) handler(this, e);
        }


        
    }
}