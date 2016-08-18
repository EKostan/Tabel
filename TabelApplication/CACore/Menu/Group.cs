using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CACore.Menu
{
    public class Group : IGroup
    {
        public Group()
        {
            AllowMinimize = true;
        }

        public Group(ICollection<IItem> items)
            : this()
        {
            AddItems(items);
        }

        List<IItem> _items = new List<IItem>();

        public string Key { get; set; }
        public string DisplayName { get; set; }


        public void AddItems(ICollection<IItem> items)
        {
            _items.AddRange(items);

            foreach (var item in items)
            {
                item.Group = this;
                item.VisibleChanged += item_VisibleChanged;
            }

            UpdateVisible();
        }


        public void AddItem(IItem item)
        {
            _items.Add(item);
            item.Group = this;
            item.VisibleChanged += item_VisibleChanged;

            UpdateVisible();
        }

        public void RemoveItem(IItem item)
        {
            if(!_items.Contains(item))
                return;

            _items.Remove(item);
            item.Group = null;
            item.VisibleChanged -= item_VisibleChanged;

            UpdateVisible();
        }

        private bool _visible;

        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnVisibleChanged();
            }
        }

        void item_VisibleChanged(object sender, System.EventArgs e)
        {
            UpdateVisible();
        }

        void UpdateVisible()
        {
            Visible = HasVisibleItems();
        }

        private bool HasVisibleItems()
        {
            foreach (var item in _items)
            {
                if (item.Visible)
                    return true;
            }

            return false;
        }

        public event EventHandler VisibleChanged;
        public bool AllowMinimize { get; set; }

        public ReadOnlyCollection<IItem> Items 
        {
            get { return new ReadOnlyCollection<IItem>(_items);}
        }

        protected virtual void OnVisibleChanged()
        {
            var handler = VisibleChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

    }
}