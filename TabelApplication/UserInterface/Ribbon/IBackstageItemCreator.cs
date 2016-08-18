using CACore.Menu;
using DevExpress.XtraBars.Ribbon;

namespace UserInterface.Ribbon
{
    interface IBackstageItemCreator
    {
        BackstageViewItem Create(IItem item);
    }
}