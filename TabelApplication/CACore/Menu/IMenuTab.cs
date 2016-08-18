using System.Collections.Generic;

namespace CACore.Menu
{
    public interface IMenuTab
    {
        string Key { get; set; }
        string DisplayName { get; set; }

        ICollection<IGroup> Groups { get; set; }
    }
}
