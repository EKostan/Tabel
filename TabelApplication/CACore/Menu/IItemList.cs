using System.Collections.Generic;

namespace CACore.Menu
{
    public interface IItemList : IItem
    {
        ICollection<IItem> Items { get; set; }
    }
}