using CACore.Menu;
using DevExpress.XtraBars;

namespace UserInterface.Ribbon
{
    class BarItemCreatorCheckBox : BaseBarItemCreator
    {
        protected override BarItem DoCreate(IItem item)
        {
            return new BarCheckItem()
            {
                Caption = item.DisplayName, 
                Hint = item.Hint,
                Tag = item,
                Enabled = item.Enabled,
                Visibility = item.Visible ? BarItemVisibility.Always : BarItemVisibility.Never
            };
        }
    }
}
