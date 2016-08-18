using System;
using System.Drawing;

namespace CACore.Menu
{
    public interface IItem
    {
        string Key { get; set; }
        string DisplayName { get; set; }

        string Hint { get; set; }

        Icon Icon { get; set; }

        Icon LargeIcon { get; set; }

        bool Enabled { get; set; }
        event EventHandler EnableChanged;

        bool Visible { get; set; }
        event EventHandler VisibleChanged;

        IGroup Group { get; set; }

        void Execute();


    }
}