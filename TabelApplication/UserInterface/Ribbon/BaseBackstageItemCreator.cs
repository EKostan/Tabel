using CACore.Menu;
using DevExpress.XtraBars.Ribbon;

namespace UserInterface.Ribbon
{
    abstract class BaseBackstageItemCreator : IBackstageItemCreator
    {
        public BackstageViewItem Create(IItem item)
        {
            return DoCreate(item);
        }

        protected abstract BackstageViewItem DoCreate(IItem item);
    }
}