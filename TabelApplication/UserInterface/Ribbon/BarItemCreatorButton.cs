using System;
using CACore.Menu;
using DevExpress.XtraBars;

namespace UserInterface.Ribbon
{
    class BarItemCreatorButton : BaseBarItemCreator
    {
        protected override BarItem DoCreate(IItem item)
        {
            var bbi = new BarButtonItem()
            {
                Caption = item.DisplayName, 
                Hint = item.Hint,  
                Tag = item,
                Enabled = item.Enabled,
                Visibility = item.Visible ? BarItemVisibility.Always : BarItemVisibility.Never
            };

            var controller = new BarButtonItemController(item, bbi);

            return bbi;
        }

    }

    internal class BarButtonItemController : IDisposable
    {
        private IItem _item;
        private BarButtonItem _barButtonItem;

        public BarButtonItemController(IItem item, BarButtonItem barButtonItem)
        {
            _item = item;
            _barButtonItem = barButtonItem;

            SignEvents();
        }

        private void SignEvents()
        {
            _item.EnableChanged += ItemEnableChanged;
            _item.VisibleChanged += _item_VisibleChanged;
            _barButtonItem.Disposed += _barButtonItem_Disposed;
        }

        void _item_VisibleChanged(object sender, EventArgs e)
        {
            _barButtonItem.Visibility = _item.Visible ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        void _barButtonItem_Disposed(object sender, EventArgs e)
        {
            Dispose();
        }

        void ItemEnableChanged(object sender, EventArgs e)
        {
            _barButtonItem.Enabled = _item.Enabled;
        }

        public void Dispose()
        {
            _item.EnableChanged -= ItemEnableChanged;
            _item.VisibleChanged -= _item_VisibleChanged;
            _barButtonItem.Disposed -= _barButtonItem_Disposed;

        }
    }

}