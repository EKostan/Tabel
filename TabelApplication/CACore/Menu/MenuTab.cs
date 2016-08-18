using System.Collections.Generic;

namespace CACore.Menu
{
    public class MenuTab : IMenuTab
    {
        List<IGroup> _groups = new List<IGroup>();

        public string Key { get; set; }
        public string DisplayName { get; set; }

        public ICollection<IGroup> Groups
        {
            get { return _groups; }
            set { _groups = new List<IGroup>(value); }
        }
    }
}