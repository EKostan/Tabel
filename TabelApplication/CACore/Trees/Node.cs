using System.Collections.Generic;
using System.Drawing;
using CACore.Trees.Actions;
using Core.Plugins;

namespace CACore.Trees
{
    public abstract class Node : INode
    {
        protected Node()
        {
            Nodes = new List<INode>();

            var attributeDelete = Attributer.GetAttribute<DeleteActionAtribute>(this.GetType());

            if (attributeDelete != null)
                _actions.Add(new DeleteNodeAction(this));

        }

        public string DisplayName { get; set; }
        public string Description { get; set; }

        public string Key { get; set; }
        public Icon Icon { get; set; }
        public INode Parent { get; set; }
        public bool Visible { get; set; }
        public ICollection<INode> Nodes { get; set; }

        public bool HasChildren
        {
            get { return Nodes.Count > 0; }
        }

        public Tree Tree { get; set; }


        private bool _checked = false;
        
        /// <summary>
        /// Состояние галочки
        /// </summary>
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnCheckedChanged();
                
                State = _checked;
            }
        }

        private bool _state = false;
        
        /// <summary>
        /// Состояние отображения галочки
        /// </summary>
        public bool State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnStateChanged();
            }
        }

        protected virtual void OnStateChanged()
        {
            
        }

        private bool _expanded = false;

        public bool Expanded
        {
            get { return _expanded; }
            set { _expanded = value; }
        }

        protected virtual void OnCheckedChanged()
        {
            
        }

        List<IAction> _actions = new List<IAction>();
        public ICollection<IAction> Actions 
        {
            get { return _actions; }
            set { _actions = new List<IAction>(value); }
        }

        public virtual INodeStatus NodeStatus { get; set; }
    }
}