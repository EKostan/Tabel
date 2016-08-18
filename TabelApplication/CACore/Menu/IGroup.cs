using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CACore.Menu
{
    public interface IGroup
    {
        string Key { get; set; }
        string DisplayName { get; set; }

        void AddItems(ICollection<IItem> items);
        void AddItem(IItem item);

        void RemoveItem(IItem item);

        bool Visible { get; set; }
        event EventHandler VisibleChanged;

        bool AllowMinimize { get; set; }

        ReadOnlyCollection<IItem> Items { get; }
    }
}