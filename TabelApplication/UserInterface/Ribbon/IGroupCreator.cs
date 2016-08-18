using CACore.Menu;
using DevExpress.XtraBars.Ribbon;

namespace UserInterface.Ribbon
{
    interface IGroupCreator
    {
        RibbonPageGroup Create(IGroup item);

    }
}
