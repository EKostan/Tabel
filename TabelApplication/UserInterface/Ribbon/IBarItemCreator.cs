using CACore.Menu;
using DevExpress.XtraBars;

namespace UserInterface.Ribbon
{
    interface IBarItemCreator
    {
        BarItem Create(IItem item);
    }
}