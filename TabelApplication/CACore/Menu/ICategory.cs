using System;
using System.Collections.Generic;

namespace CACore.Menu
{
    public interface ICategory
    {
        string Key { get; set; }

        string Name { get; set; }

        List<IMenuTab> Tabs { get; set; }
        bool Visible { get; set; }

        event EventHandler VisibleChanged;
        IMenuTab GetTabByKey(string tabKey);
    }

    public class Category : ICategory
    {
        public Category()
        {
            Tabs = new List<IMenuTab>();
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public List<IMenuTab> Tabs { get; set; }

        private bool _visible = false;

        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    OnVisibleChanged();
                }
            }
        }
        public event EventHandler VisibleChanged;
        
        public IMenuTab GetTabByKey(string tabKey)
        {
            foreach (var menuTab in Tabs)
            {
                if (menuTab.Key.Equals(tabKey))
                    return menuTab;
            }

            return null;
        }

        protected virtual void OnVisibleChanged()
        {
            var handler = VisibleChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}