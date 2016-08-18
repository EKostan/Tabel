using System;

namespace CACore.Menu
{
    public interface IItemDateEdit : IItem
    {
        DateTime Date { get; set; }
        event EventHandler<DateTime> DateChanged;
    }
}