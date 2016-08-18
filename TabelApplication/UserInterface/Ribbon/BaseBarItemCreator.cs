using CACore.Menu;
using DevExpress.XtraBars;

namespace UserInterface.Ribbon
{
    abstract class BaseBarItemCreator : IBarItemCreator
    {
        public BarItem Create(IItem item)
        {
            return DoCreate(item);
        }

        protected abstract BarItem DoCreate(IItem item);
    }
}